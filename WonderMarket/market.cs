using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class market
    {
        public int time; /* absolutni cas poute*/
        public int distance = 6;
        public int konec;
        public int stallsn;
        public bool open;
        public List<visitor> visitors = new List<visitor>(); /* seznam navstevniku */
        public List<stall> stalls = new List<stall>(); /* seznam stanku */
        public List<MarketEvent> almanac = new List<MarketEvent>(); /* kalendar udalosti */
        public market(int stallsn, int konec) /* inicializace trhu */
        {
            this.open = true;
            this.stallsn = stallsn;
            this.konec = konec;
            Random random = new Random();
            for (int i = 1; i < this.stallsn + 1; i++)  /* vytvori stalls stanku a pojmenuje je cisly */
            {
                stall s = new stall(i, random);
                this.stalls.Add(s);
            }
                this.time = 0; /*nastavi cas na 0 minut */
                Console.Write(" Juchuuu, market is open and its zero o'clock! "); Console.WriteLine();
        }
    }
}
