using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Hra hra;
       
        public Form1()
        {
            InitializeComponent();
            hra = new Hra();
            hra.reseni.NahodneReseni();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
               Graphics g = e.Graphics;

            // vykresli sede kruznice jako hranice kulicek
               for (int i = Def.ZacatekX; i < Def.ZacatekX+Def.PocetKulX*(Def.PrumerKul+Def.RozestupX)-Def.RozestupX; i=i+Def.PrumerKul+Def.RozestupX)
               {
                   for (int j = Def.ZacatekY+hra.Radek*(Def.PrumerKul+Def.RozestupY); j < Def.ZacatekY + Def.PocetKulY * (Def.PrumerKul + Def.RozestupY) - Def.RozestupY; j = j + Def.PrumerKul + Def.RozestupY)
                   {
                       g.DrawEllipse(Pens.Gray, i, j, Def.PrumerKul, Def.PrumerKul);
                   }                   
               }

           //vykresli cerne kruznice u jiz hotovych radku
               for (int i = Def.ZacatekX; i < Def.ZacatekX + Def.PocetKulX * (Def.PrumerKul + Def.RozestupX) - Def.RozestupX; i = i + Def.PrumerKul + Def.RozestupX)
               {
                   for (int j = Def.ZacatekY; j < Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY); j = j + Def.PrumerKul + Def.RozestupY)
                   {
                       g.DrawEllipse(Pens.Black, i, j, Def.PrumerKul, Def.PrumerKul);
                   }
               }

               for (int i = 0; i < Def.PocetKulY-1; i++)       //vykresli sede obdelniky na zacatku
               {

                   for (int j = 0; j < Def.PocetKulX; j++)     
                   {
                       g.DrawRectangle(Pens.LightGray, Def.ZacatekNapoveda + j * (Def.SirkaNapoveda + Def.RozestupNapoveda), Def.ZacatekY + i * (Def.PrumerKul + Def.RozestupY), Def.SirkaNapoveda, Def.PrumerKul);
                   }


               }
               

               for (int i = 100; i < 200; i = i + 22)       //vykresli na zacatku cerne tajne kulicky
               {
                   g.FillEllipse(Brushes.Black, i, 30, Def.PrumerKul, Def.PrumerKul);
               }

               //vykresli na zacatku barevne kulicky na boku
               g.FillEllipse(Brushes.Blue, Def.ZacatekBarX, Def.ZacatekBarY, Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.Purple, Def.ZacatekBarX, Def.ZacatekBarY+Def.PrumerKul+Def.RozestupY, Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.Yellow, Def.ZacatekBarX, Def.ZacatekBarY + 2*(Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.Red, Def.ZacatekBarX, Def.ZacatekBarY + 3 * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.Orange, Def.ZacatekBarX, Def.ZacatekBarY + 4 * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.Green, Def.ZacatekBarX, Def.ZacatekBarY + 5 * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.DarkTurquoise, Def.ZacatekBarX, Def.ZacatekBarY + 6 * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
               g.FillEllipse(Brushes.DarkSalmon, Def.ZacatekBarX, Def.ZacatekBarY + 7 * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);

               pictureBox1.Invalidate();

            if(hra.C[hra.Radek])       //vykresli sede kolo kdyz zmacknem na kulicku
            {
                g.FillEllipse(Brushes.LightGray, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);       
                            
            }
            
            if(hra.E)     //vykresli nove navolenou barevnou kulicku
            {
                switch (hra.Barva[hra.Sloupec,hra.Radek])
                {

                    case 0:
                        g.FillEllipse(Brushes.Blue, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;
                    
                    case 1:
                        g.FillEllipse(Brushes.Purple, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;

                    case 2:
                        g.FillEllipse(Brushes.Yellow, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;

                    case 3:
                        g.FillEllipse(Brushes.Red, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;

                    case 4:
                        g.FillEllipse(Brushes.Orange, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;

                    case 5:
                        g.FillEllipse(Brushes.Green, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;

                    case 6:
                        g.FillEllipse(Brushes.DarkTurquoise, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;
                    case 7:
                        g.FillEllipse(Brushes.DarkSalmon, Def.ZacatekX + hra.Sloupec * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + hra.Radek * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                        break;
                      
                } 
            }

            for(int i=0;i<Def.PocetKulX;i++)        //vykresli stare zvolene kulicky
            {
                for (int j = 0; j <= hra.Radek; j++)
                {
                    switch (hra.Barva[i, j])
                    {

                        case 0:
                            g.FillEllipse(Brushes.Blue, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY+j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 1:
                            g.FillEllipse(Brushes.Purple, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 2:
                            g.FillEllipse(Brushes.Yellow, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 3:
                            g.FillEllipse(Brushes.Red, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 4:
                            g.FillEllipse(Brushes.Orange, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 5:
                            g.FillEllipse(Brushes.Green, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 6:
                            g.FillEllipse(Brushes.DarkTurquoise, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;
                        case 7:
                            g.FillEllipse(Brushes.DarkSalmon, Def.ZacatekX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekY + j * (Def.PrumerKul + Def.RozestupY), Def.PrumerKul, Def.PrumerKul);
                            break;
                    }
                }
            }

            for (int i = 0; i < hra.Radek; i++)
            {

                for (int j = 0; j < hra.Dobre[i]; j++)     //vykresli bile obdelniky
                {
                    g.FillRectangle(Brushes.Black, Def.ZacatekNapoveda + j * (Def.SirkaNapoveda + Def.RozestupNapoveda), Def.ZacatekY + i * (Def.PrumerKul + Def.RozestupY), Def.SirkaNapoveda, Def.VyskaNapoveda);
                    g.DrawRectangle(Pens.Gray, Def.ZacatekNapoveda + j * (Def.SirkaNapoveda + Def.RozestupNapoveda), Def.ZacatekY + i * (Def.PrumerKul + Def.RozestupY), Def.SirkaNapoveda, Def.VyskaNapoveda);
                }

                for (int j = hra.Dobre[i]; j < hra.Dobre[i] + hra.Jinde[i]; j++)     //vykresli cerne obdelniky
                {
                    g.FillRectangle(Brushes.White, Def.ZacatekNapoveda + j * (Def.SirkaNapoveda + Def.RozestupNapoveda), Def.ZacatekY + i * (Def.PrumerKul + Def.RozestupY), Def.SirkaNapoveda, Def.VyskaNapoveda);
                    g.DrawRectangle(Pens.Gray, Def.ZacatekNapoveda + j * (Def.SirkaNapoveda + Def.RozestupNapoveda), Def.ZacatekY + i * (Def.PrumerKul + Def.RozestupY), Def.SirkaNapoveda, Def.VyskaNapoveda);
                }
            }

            if (hra.Vyhra || hra.Prohra)
            {
                for (int i = 0; i < Def.PocetKulX; i++)        //vykresli na konci tajne kulicky
                {
                    switch (hra.reseni.BarvaRes[i])
                    {

                        case 0:
                            g.FillEllipse(Brushes.Blue, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 1:
                            g.FillEllipse(Brushes.Purple, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 2:
                            g.FillEllipse(Brushes.Yellow, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 3:
                            g.FillEllipse(Brushes.Red, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 4:
                            g.FillEllipse(Brushes.Orange, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 5:
                            g.FillEllipse(Brushes.Green, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;

                        case 6:
                            g.FillEllipse(Brushes.DarkTurquoise, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;
                        case 7:
                            g.FillEllipse(Brushes.DarkSalmon, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                            break;
                    }
                    g.DrawEllipse(Pens.Black, Def.ZacatekTajX + i * (Def.PrumerKul + Def.RozestupX), Def.ZacatekTajY, Def.PrumerKul, Def.PrumerKul);
                }
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {     
            hra.Kliknuti1(e.Location.X, e.Location.Y);      
            
            if(hra.Sloupec>-1)
            {
                hra.Kliknuti2(e.Location.X, e.Location.Y);
            }
            
          pictureBox1.Invalidate();
        }

        private void btnZkontroluj_Click(object sender, EventArgs e)
        {
            hra.Kontrola();
            btnZkontroluj.Invalidate();
            if (hra.Vyhra)
            {
                MessageBox.Show("Vyhrali jste!\rHra se nyni ukonci", "", MessageBoxButtons.OK);
                Close();
            }
            if(hra.Prohra)
            {
                MessageBox.Show("Prohrali jste.\rHra se nyni ukonci", "", MessageBoxButtons.OK);
                Close();
            }
        }

        private void btnPravidla_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Vitejte u hry Logik.\rVasim ukolem je odhalit spravne poradi kulicek, ktere nahodne vybral pocitac. Kulicky se mohou opakovat. Nejprve vyberte kulicku na prvnim radku a priradte ji barvu. To muzete udelat pro vice kulicek na radku. Po stisknuti tlacitka Zkontroluj se pro dany radek zobrazi tolik cernych obdelniku, kolikrat jste se trefili barvou i umistenim, a tolik bilych, kolikrat jste se trefili barvou, ale ne umistenim. Pote pokracujete na dalsich radcich, dokud nezvitezite, nebo nevycerpate vsechny radky.", "Pravidla", MessageBoxButtons.OK);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdfasdf");
        }
    }
}
