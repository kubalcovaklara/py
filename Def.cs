using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Def
    {
        public const int RozestupX = 2;
        public const int RozestupY = 5;
        public const int PrumerKul = 20;
        public const int PocetKulX = 5;             //pocet kulicek na hadani
        public const int PocetKulY = 10;
        public const int ZacatekX = 100;            //zacatek kulicek na hadani
        public const int ZacatekY = 70;
        public const int ZacatekBarX = 35;          //zacatek barevnych kulicek
        public const int ZacatekBarY = 100;
        public const int ZacatekTajX = 100;          //zacatek tajnych cernych kulicek
        public const int ZacatekTajY = 30;
        public const int ZacatekNapoveda = ZacatekX+PocetKulX*PrumerKul+(PocetKulX-1)*RozestupY+10;
        public const int RozestupNapoveda = 8;
        public const int SirkaNapoveda = 5;
        public const int VyskaNapoveda = PrumerKul;
    }
}
