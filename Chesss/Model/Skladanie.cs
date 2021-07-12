using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Chesss.Model
{
    class Skladanie
    {
        public static ObservableCollection<string> Zloz(ObservableCollection<Szachisci> szach, ObservableCollection<Rozgrywki> roz)
        {
            ObservableCollection<string> zlozona = new ObservableCollection<string>();
            string tmp1 = "";
            string tmp2 = "";
            string kazda;
            foreach (var x in roz)
            {
                sbyte g1 = x.bialy;
                sbyte g2 = x.czarny;
                foreach (var y in szach)
                {
                    if (g1 == y.id)
                    {
                        tmp1 = y.imie + " " + y.nazwisko;
                    }
                    if (g2 == y.id)
                    {
                        tmp2 = y.imie + " " + y.nazwisko;
                    }
                }
                kazda = tmp1 + " vs " + tmp2 + ", " + x.debiut + ", " + x.data;
                zlozona.Add(kazda);
            }

            return zlozona;
        }

        public static ObservableCollection<sbyte> ZbierzID(ObservableCollection<Rozgrywki> roz)
        {
            ObservableCollection<sbyte> id = new ObservableCollection<sbyte>();
            foreach (var i in roz)
            {
                id.Add(i.id);
            }
            return id;
        }

        public static string AktualnaGra(ObservableCollection<Rozgrywki> roz, ObservableCollection<sbyte> id, int num)
        {
            sbyte i = id.ElementAt(num);
            string wyjscie = "";
            foreach (var g in roz)
            {
                if (g.id == i)
                {
                    wyjscie = g.ruchy;
                }
            }
            return wyjscie;
        }

        public static string Zwyciezyl(ObservableCollection<Rozgrywki> roz, ObservableCollection<sbyte> id, int num)
        {
            sbyte i = id.ElementAt(num);
            string wyjscie = "";
            foreach (var g in roz)
            {
                if (g.id == i)
                {
                    wyjscie = g.zwyciezca;
                }
            }
            return wyjscie;
        }
    }
}
