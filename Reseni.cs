using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Reseni
    {
        private int[] barvaRes;
        Random rnd=new Random();


        public Reseni()
        {
            barvaRes=new int[Def.PocetKulX];
        }
        
        public int[] BarvaRes
        {
            get { return barvaRes; }
        }

        public void NahodneReseni()     //nahodne vybere reseni
        {
            for(int i=0; i<Def.PocetKulX; i++)
            {
                barvaRes[i] = rnd.Next(8);
            }

        }
       
    }
}
