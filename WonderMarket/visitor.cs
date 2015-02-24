using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class visitor
    {
        public int arrival_time;
        public int amount_of_money;
        public int namew;
        public List<int> preference = new List<int>();
        public visitor(int arr_time, int number_stalls, Random random_item, int namew)
        {
            this.namew = namew;
            this.arrival_time = arr_time;
            this.amount_of_money = random_item.Next(1,500);
            
            for (int i=1; i<number_stalls;i++)
            {
                int cislo = random_item.Next(1,number_stalls);
                this.preference.Add(cislo);
            }
        }
    }
}
