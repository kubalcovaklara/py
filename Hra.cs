using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Hra
       
    {
        protected bool[] c;             //kdyz je pravda, vykresli se seda kulicka
        protected int sloupec;
        protected bool e;               //kdyz je pravda, vykresli se barevna kulicka
        protected int radek;
        protected bool prohra;
        protected int[,] barva;
        protected int[] dobre;
        protected int[] jinde;
        protected int[] pomocna;        
        protected int[] pomocnaRes;
        protected bool vyhra;
        public Reseni reseni;

        public Hra()
        {
            c = new bool[Def.PocetKulY];
            sloupec = -1;
            e = false;
            radek = 0;
            prohra = false;
            barva = new int[Def.PocetKulX,Def.PocetKulY];
            dobre = new int[Def.PocetKulY];
            jinde = new int[Def.PocetKulY];
            pomocna = new int[8];
            pomocnaRes = new int[8];
            vyhra = false;
    
            for(int i=0;i<Def.PocetKulX;i++)
            {
                for (int j = 0; j < Def.PocetKulY; j++)     //zadne pole nema zadnou barvu
                {
                    barva[i, j] = -2;
                }
            }   
            reseni=new Reseni();
        }

        public bool[] C
        {
            get { return c; }
        }

        public int Sloupec
        {
            get { return sloupec; }
        }

        public bool E
        {
            get { return e; }
        }

        public int Radek
        {
            get { return radek; }
        }
        
        public bool Prohra
        {
            get { return prohra; }
        }

        public int[,] Barva
        {
            get { return barva; }
        }

        public int[] Dobre
        {
            get { return dobre; }
        }
        
        public int[] Jinde
        {
            get { return jinde; }
        }

        public int[] Pomocna
        {
            get { return pomocna; }
        }

        public int[] PomocnaRes
        {
            get { return pomocnaRes; }
        }

        public bool Vyhra
        {
            get { return vyhra; }
        }


        public void Kliknuti1(int a, int b)   //kontroluje, zda je vybrana kulicka k obarveni
        {
           int x;
            int y;

            try
            {
                if ((a >= Def.ZacatekX) && (a <= Def.ZacatekX + Def.PocetKulX * (Def.PrumerKul + Def.RozestupX) - Def.RozestupX) && (b >= Def.ZacatekY + radek * (Def.PrumerKul + Def.RozestupY)) && (b <= Def.ZacatekY + (radek + 1) * (Def.PrumerKul + Def.RozestupY) - Def.RozestupY))       //kontroluje, zda je kliknuti v "obdelniku" z rady kulicek
                {

                    y = b - (Def.ZacatekY + (2 * radek + 1) * Def.PrumerKul / 2 + radek * Def.RozestupY);       //posunuti b do souradnic na kontrolu

                    for (int i = 0; i < Def.PocetKulX; i++)
                    {
                        if ((a >= Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX)) && (a < Def.ZacatekX + (i + 1) * (Def.PrumerKul + Def.RozestupX)))
                        {
                            x = a - (Def.ZacatekX + (2 * i + 1) * Def.PrumerKul / 2 + i * Def.RozestupX);     //posunuti a do souradnic na kontrolu

                            if ((x * x + y * y) <= (Def.PrumerKul / 2) * (Def.PrumerKul / 2))              //kontrola, zda jsme se trefili do kulicky
                            {
                                c[radek] = true;
                                sloupec = i;
                            }
                        }
                    }
                }
            }
            catch
            {
                c[radek] = false;
            }       
        }

        public void Kliknuti2(int a, int b)     //prirazuje kulicce zvolenou barvu
        {
            int x;
            int y;

            try
            {
                if ((a >= Def.ZacatekBarX) && (a <= Def.ZacatekBarX + Def.PrumerKul) && (b >= Def.ZacatekBarY) && (b <= Def.ZacatekBarY + 8 * Def.PrumerKul + 7 * Def.RozestupY))       //kontroluje, zda je kliknuti v "obdelniku" z rady kulicek
                {

                    x = a - Def.ZacatekBarX - Def.PrumerKul / 2;       //posunuti a do souradnic na kontrolu

                    for (int i = 0; i < 8; i++)
                    {
                        if ((b >= Def.ZacatekBarY + i * (Def.PrumerKul + Def.RozestupY)) && (b < Def.ZacatekBarY + (i + 1) * (Def.PrumerKul + Def.RozestupY)))
                        {
                            y = b - (Def.ZacatekBarY + (2 * i + 1) * Def.PrumerKul / 2 + i * Def.RozestupY);     //posunuti b do souradnic na kontrolu

                            if ((x * x + y * y) <= (Def.PrumerKul / 2) * (Def.PrumerKul / 2))              //kontrola, zda jsme se trefili do kulicky
                            {
                                e = true;
                                barva[sloupec, radek] = i;
                            }
                        }
                    }
                }
            }
            catch
            {
                e = false;
            }
        }

        public void Kontrola()          //Po stisknuti btnZkontroluj provede srovnani hadanych kulicek se spravnym resenim
        {
            dobre[radek] = 0;
            jinde[radek] = 0;
            
            int k = 0;

            for(int i=0;i<Def.PocetKulX;i++)
            {

                if(barva[i,radek]==reseni.BarvaRes[i])
                {
                    dobre[radek]++;
                }
                else
                {
                    pomocna[k] = barva[i,radek];
                    pomocnaRes[k] = reseni.BarvaRes[i];
                    k++;
                }
            }

            int l = k;

            for(int i=0;i<k;i++)
            {
                for(int j=0;j<l;j++)
                {
                    if(pomocna[i]==pomocnaRes[j])
                    {
                        jinde[radek]++;
                        pomocnaRes[j] = -1;
                        break;
                    }
                }
            }
            
            if(dobre[radek]==Def.PocetKulX)         //vyhodnocuje vyhru/prohru/pokracovani na dalsim radku
            {
                vyhra = true;
                c[radek] = false;
            }
            else if (radek == Def.PocetKulY-1)
            {
                prohra = true;
                c[radek] = false;
            }
            else
            {
                radek++;
            }

            e = false;
            sloupec = -1;
        }
    }
}
