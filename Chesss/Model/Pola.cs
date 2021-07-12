using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesss.Model
{
    class Pola
    {
        public ObservableCollection<string> Pole = new ObservableCollection<string>();
        public ObservableCollection<string> Zbite = new ObservableCollection<string>();
        public int ind;
        public Pola()
        {
            ind = 0;
            for (int i = 0; i < 64; i++)
            {
                Pole.Add("");
            }
            #region
            for (int i = 8; i < 16; i++)
            {
                if(i % 2 == 0)
                this.Pole[i] = "bpb.png";
                else this.Pole[i] = "bpc.png";
            }
            for (int i = 48; i < 56; i++)
            {
                if(i % 2 == 0)
                this.Pole[i] = "cpc.png";
                else this.Pole[i] = "cpb.png";
            }
            for (int i = 16; i < 24; i++)
            {
                if (i % 2 == 1)
                    this.Pole[i] = "pb.png";
                else
                    this.Pole[i] = "pc.png";
            }
            for (int i = 24; i < 32; i++)
            {
                if (i % 2 == 1)
                    this.Pole[i] = "pc.png";
                else
                    this.Pole[i] = "pb.png";
            }
            for (int i = 32; i < 40; i++)
            {
                if (i % 2 == 1)
                    this.Pole[i] = "pb.png";
                else
                    this.Pole[i] = "pc.png";
            }
            for (int i = 40; i < 48; i++)
            {
                if (i % 2 == 1)
                    this.Pole[i] = "pc.png";
                else
                    this.Pole[i] = "pb.png";
            }
            #endregion
            Pole[0] = "bwc.png"; Pole[7] = "bwb.png"; Pole[1] = "bsb.png"; Pole[6] = "bsc.png"; Pole[2] = "bgc.png"; Pole[5] = "bgb.png"; Pole[3] = "bhb.png"; Pole[4] = "bkc.png";
            Pole[63] = "cwc.png"; Pole[56] = "cwb.png"; Pole[57] = "csc.png"; Pole[62] = "csb.png"; Pole[58] = "cgb.png"; Pole[61] = "cgc.png"; Pole[59] = "chc.png"; Pole[60] = "ckb.png";
        }
        public static bool IsNumeric(string t1)
        {
            int t2;
            return int.TryParse(t1, out t2);
        }
        public static bool IsBig(char znak)
        {
            if (znak > 64 && znak < 91)
                return true;
            return false;
        }
        public static int Policz(string kolumna)
        {
            int dodatnia = 0;
            if (kolumna.ToString() == "b") dodatnia = 1;
            else if (kolumna.ToString() == "c") dodatnia = 2;
            else if (kolumna.ToString() == "d") dodatnia = 3;
            else if (kolumna.ToString() == "e") dodatnia = 4;
            else if (kolumna.ToString() == "f") dodatnia = 5;
            else if (kolumna.ToString() == "g") dodatnia = 6;
            else if (kolumna.ToString() == "h") dodatnia = 7;
            return dodatnia;
        }
        public static int Przelicz(string kolumna, string rzad)
        {
            int calosc = 0;
            int dodatnia = Policz(kolumna);
            int mnoznik = int.Parse(rzad.ToString()) - 1;
            calosc = mnoznik * 8 + dodatnia;
            return calosc;
        }
        public ObservableCollection<string> Przestaw(string ruch, bool NextOrPrev)
        {
            try
            {
                string cyfra = ruch[0].ToString();
                int indeks = 0;
                int indeksPola1 = 0;
                int indeksPola2 = 0;
                char figura = 'p';
                bool ruchbialych = false;
                bool zbicie = false;
                string kolor = "c";
                string kolor2 = "b";

                if (IsNumeric(cyfra) == true)
                {
                    indeks = ruch.IndexOf(".") + 1;
                    ruchbialych = true;
                    kolor = "b";
                    //string[] bufor = ruch.Split(".");
                }
                if (ruch[indeks].ToString() == "O")   // przypadek roszady
                {
                    if (NextOrPrev == true)
                    {
                        if (indeks + 4 < ruch.Length)     // to znaczy, że to długa roszada
                        {
                            if (ruchbialych == true)
                            {
                                Pole[0] = "pc.png";
                                Pole[4] = "pc.png";
                                Pole[3] = "bwb.png";
                                Pole[2] = "bkc.png";
                            }
                            else
                            {
                                Pole[56] = "pb.png";
                                Pole[60] = "pb.png";
                                Pole[59] = "cwc.png";
                                Pole[58] = "ckb.png";
                            }
                        }
                        else
                        {
                            if (ruchbialych == true)
                            {
                                Pole[4] = "pc.png";
                                Pole[5] = "bwb.png";
                                Pole[7] = "pb.png";
                                Pole[6] = "bkc.png";
                            }
                            else
                            {
                                Pole[60] = "pb.png";
                                Pole[63] = "pc.png";
                                Pole[61] = "cwc.png";
                                Pole[62] = "ckb.png";
                            }
                        }
                    }
                    else
                    {
                        if (indeks + 4 < ruch.Length)     // to znaczy, że to długa roszada
                        {
                            if (ruchbialych == true)
                            {
                                Pole[2] = "pc.png";
                                Pole[3] = "pb.png";
                                Pole[0] = "bwc.png";
                                Pole[4] = "bkc.png";
                            }
                            else
                            {
                                Pole[56] = "cwb.png";
                                Pole[60] = "ckb.png";
                                Pole[59] = "pc.png";
                                Pole[58] = "pb.png";
                            }
                        }
                        else
                        {
                            if (ruchbialych == true)
                            {
                                Pole[4] = "bkc.png";
                                Pole[5] = "pb.png";
                                Pole[7] = "bwb.png";
                                Pole[6] = "pc.png";
                            }
                            else
                            {
                                Pole[60] = "ckb.png";
                                Pole[63] = "cwc.png";
                                Pole[61] = "pc.png";
                                Pole[62] = "pb.png";
                            }
                        }
                    }
                    return Pole;
                }
                if (IsBig(ruch[indeks]))                                     // jesli nie jest duza, to znaczy, ze przesuwa sie pion
                {
                    char buf = char.Parse(ruch[indeks].ToString());
                    figura = System.Convert.ToChar(buf + 32);                // zmiana na male litery
                    indeks++;
                }

                int rzad;
                int kolumna;
                int rzad2;
                int kolumna2;
                string kolor3 = "b";
                if (NextOrPrev == true)
                {
                    rzad = int.Parse(ruch[indeks + 1].ToString()) - 1;
                    kolumna = Policz(ruch[indeks].ToString());
                    rzad2 = int.Parse(ruch[indeks + 4].ToString()) - 1;
                    kolumna2 = Policz(ruch[indeks + 3].ToString());
                }
                else
                {
                    rzad = int.Parse(ruch[indeks + 4].ToString()) - 1;
                    kolumna = Policz(ruch[indeks + 3].ToString());
                    rzad2 = int.Parse(ruch[indeks + 1].ToString()) - 1;
                    kolumna2 = Policz(ruch[indeks].ToString());
                }

                indeksPola1 = Przelicz(ruch[indeks].ToString(), ruch[indeks + 1].ToString());
                indeks += 2;
                if (ruch[indeks].ToString() == ":") zbicie = true;
                indeks += 1;
                indeksPola2 = Przelicz(ruch[indeks].ToString(), ruch[indeks + 1].ToString());

                if (rzad % 2 == 0)
                {
                    if ((rzad + kolumna) % 2 == 0) kolor2 = "c";
                }
                else
                {
                    if ((rzad + kolumna) % 2 == 0) kolor2 = "c";
                }
                if (rzad2 % 2 == 0)
                {
                    if ((rzad2 + kolumna2) % 2 == 0) kolor3 = "c";
                }
                else
                {
                    if ((rzad2 + kolumna2) % 2 == 0) kolor3 = "c";
                }
                if (NextOrPrev == true)
                {
                    if (zbicie == true) { Zbite.Add(Pole[indeksPola2]); ind++; }

                    Pole[indeksPola1] = "p" + kolor2 + ".png";                 // pole, które będzie puste
                    Pole[indeksPola2] = kolor + figura.ToString() + kolor3 + ".png";
                }
                else
                {
                    if (zbicie == true)
                    {
                        ind--;
                        Pole[indeksPola2] = Zbite[ind];
                        Zbite.RemoveAt(ind);
                    }
                    else
                        Pole[indeksPola2] = "p" + kolor2 + ".png";
                    Pole[indeksPola1] = kolor + figura.ToString() + kolor3 + ".png";
                }
                return Pole;
            }
            catch { //Pole = new ObservableCollection<string>(); return Pole; 
                Pole[4] = "ckc.png";
                Pole[60] = "bkb.png";
                return Pole;
            }
        }
    }
}