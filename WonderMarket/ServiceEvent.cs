using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class ServiceEvent : MarketEvent
    {
        public visitor v;
        public stall s;
        
        public ServiceEvent(int time,visitor v, stall s)
        {
            this.action_time = time;
            this.s = s;
            this.v = v;
            this.theend = false;
        }
        public override void action(market place)
        {
            if (place.konec > this.action_time )
            {
                this.s.active = true;
                this.s.gain = s.gain + s.price;
                this.v.amount_of_money = v.amount_of_money - s.price;

                DecEvent decis = new DecEvent(this.action_time + this.s.service_time, this.v);
                place.almanac.Add(decis);
                place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));

                PassiveEvent pasiv = new PassiveEvent(this.action_time + this.s.service_time, this.s);
                place.almanac.Add(pasiv);
                place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));

                this.s.line.Remove(this.v);
        
                Console.Write(" Navstevnik "); Console.Write(this.v.namew); 
                Console.Write(" se nechal obslouzit u stanku cislo "); Console.Write(this.s.name);
                Console.Write(" a utratil "); Console.Write(this.s.price); Console.Write(" korun. "); Console.WriteLine();
            }
            else
            {
                if (place.open == true)
                {
                    Console.Write(" Navstevnik "); Console.Write(this.v.namew);
                    Console.Write(" prisel pozde na to, aby se nechal obslouzit. ");  // navstevnik nema cas se zaradit do fronty
                    Console.WriteLine();
                    
                    FinishEvent zaver = new FinishEvent(place.konec);
                    place.almanac.Add(zaver);

                    place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));
                }
                else
                { place.visitors.Remove(this.v); }
            }

        }
    }
}
