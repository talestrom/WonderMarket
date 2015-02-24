using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class stall
    {
        public int name;
        public bool active;
        public int price;
        public int service_time;
        public int gain;
        public List<visitor> line = new List<visitor>();
        public stall(int naem, Random random)
        {
            this.name = naem;
            this.gain = 0;
            this.active = false;
            this.price = random.Next(1,200);
            this.service_time = random.Next(1,11);
        }
    }
}
