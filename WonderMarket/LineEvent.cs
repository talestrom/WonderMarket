using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class LineEvent:MarketEvent
    {
        public visitor v;
        public stall s;
        
        public LineEvent(int time, visitor v, stall s)
        {
            this.action_time = time;
            this.v = v;
            this.s = s;
            this.theend = false;
        }
        public override void action(market place)
        {
            if (this.action_time < place.konec)
            {
                place.time = this.action_time;
                if (this.s.line.Count == 0)  // u stanku ve fronte nikdo neni
                {
                    if (this.s.active == false) // u stanku ani nikoho neobsluhuji
                    {
                        ServiceEvent service = new ServiceEvent(this.action_time + 1, v, s);   // hned naplanujeme obsluhu
                        place.almanac.Add(service);
                        place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));

                        Console.Write(" Fronta u stanku "); Console.Write(this.s.name);
                        Console.WriteLine(" je prazdna a nikdo neni zrovna obsluhovan, proto jde navstevnik ");
                        Console.Write(this.v.namew);
                        Console.Write(" rovnou ke stanku. ");   Console.WriteLine();
                    }
                    else
                    {
                        ServiceEvent service = new ServiceEvent(this.action_time + this.s.service_time, v, s);
                        place.almanac.Add(service);
                        place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));

                        this.s.line.Add(this.v);

                        Console.Write(" U stanku "); Console.Write(this.s.name);
                        Console.Write(" se zrovna nekdo obsluhuje, proto navstevnik "); Console.Write(this.v.namew);
                        Console.Write(" se zaradi do fronty jako prvni. ");
                        Console.WriteLine();
                    }
                }
                else
                {
                    this.s.line.Add(this.v);   // zaradime navstevnika do fronty

                    ServiceEvent service = new ServiceEvent(this.action_time + (this.s.line.Count * this.s.service_time),this.v,this.s);
                    place.almanac.Add(service);
                    place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));

                    Console.Write("  Fronta u stanku  "); Console.Write(this.s.name); 
                    Console.WriteLine("  neni prazdna, proto se do ni navstevnik "); Console.Write(this.v.namew);
                    Console.Write(" zaradi a ceka na svoji radu. "); Console.WriteLine();
                }
            }
            else
            {
                if (place.open == true)
                {
                    Console.Write(" Navstevnik "); Console.Write(this.v.namew);
                    Console.Write("  prisel pozde na to, aby se zaradil do fronty ");  // navstevnik nema cas se zaradit do fronty
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
