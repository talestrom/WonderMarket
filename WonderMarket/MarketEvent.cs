using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class MarketEvent
    {
        public int action_time;
        public bool theend;
        public virtual void action(market place)
        {
            Console.WriteLine(" Zustali jsme v jine tride, otcovske");
        }
    }
}
