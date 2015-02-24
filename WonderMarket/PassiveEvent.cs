using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class PassiveEvent: MarketEvent
    {
        public stall s;
        
        public PassiveEvent(int time, stall s)
        {
            this.action_time = time;
            this.s = s;
            this.theend = false;
        }
        public override void action(market place)
        {
            if (this.action_time < place.konec)
            {
                this.s.active = false;
                Console.Write(" U stanku "); Console.Write(this.s.name);
                Console.Write(" prave obslouzili zakaznika, takze se uvolnil prostor pro dalsiho ve fronte ");
                Console.WriteLine();
            }
            else
            {
                if(place.open == true)
                {
                
                    FinishEvent zaver = new FinishEvent(place.konec);
                    place.almanac.Add(zaver);

                    place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));
                }
                
            }
        }
    }
}
