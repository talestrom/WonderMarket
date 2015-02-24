using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WonderMarket
{
    public class DecEvent : MarketEvent
    {
        public visitor v;
        public bool ano;
        
        public DecEvent(int time, visitor v)
        {
            this.action_time = time;
            this.v = v;
            ano = false;
            this.theend = false;
        }
        public override void action(market place)
        {
            if (this.action_time < place.konec)
            {
                place.time = this.action_time;  // zmenili jsme cas trhu
                  
                while ((this.v.preference.Count != 0) && (ano == false)) // dokud ma navstevnik nejake stanky v preferencich
                {
                    int whereto = this.v.preference[0];  // vybrali jsme si cislo stanku, ktery ma navstevnik prvni v preferencich

                    stall kam = place.stalls.Find(item => item.name == whereto); // nasli jsme stanek, ktery odpovida cislu
                    
                    if (kam.price < this.v.amount_of_money) // overujeme, jestli ma navstevnik dost financi pro tento stanek
                    {
                        LineEvent get_in_line = new LineEvent(this.action_time + place.distance, this.v, kam);
                        place.almanac.Add(get_in_line);                                // pokud ano, naplanujeme zar. do fronty
                        place.almanac.Sort((x, y) => x.action_time.CompareTo(y.action_time));   //setridime frontu podle casu

                        Console.Write(" Navstevnik  "); Console.Write(this.v.namew); 
                        Console.Write(" se rozhodl jit ke stanku cislo ");
                        Console.Write(kam.name); Console.WriteLine(); 
                        this.v.preference.Remove(whereto); // odebereme tento stanek z preferenci navstevnika
                        ano = true; //zastavime cyklus
                    } 
                    else
                    {                    
                        this.v.preference.Remove(this.v.preference[0]); // nemame-li finance, odebereme prvek a pokracujeme v cyklu
                    }
                }

                if ((this.v.preference.Count == 0)&&(ano==false)) // pokud uz navstevnik zadne preference nema, tak odejde z trhu
                {
                    Console.Write(" Navstevnik "); Console.Write(this.v.namew);
                    Console.Write(" nemuze (nebo uz nechce) navstivit zadny stanek a jde pryc. "); Console.WriteLine();                    
                    place.visitors.Remove(this.v);
                }            
            }
            else 
             {
                if (place.open == true) // ukoncovani
                {
                    Console.Write(" Navstevnik "); Console.Write(this.v.namew);
                    Console.Write(" prisel pozde na to, aby se rozhodnul ");   // navstevnik nema cas se ani rozhodnout, kam pujde
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
