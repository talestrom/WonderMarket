using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class FinishEvent:MarketEvent
    {       
        public FinishEvent(int time)
        {
            this.action_time = time;           
            this.theend = true;
        }
        public override void action(market place)
        {
            place.open = false;
            place.time = place.konec;
            while (place.visitors.Count != 0)
            {
                place.visitors.Remove(place.visitors[0]);
            }
            Console.Write(" Trh zavira, je "); Console.Write(place.konec); Console.Write(" minut "); Console.WriteLine();
            
          
        }
    }
}
