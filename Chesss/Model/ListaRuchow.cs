using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chesss.Model
{
    class ListaRuchow
    {
        public static string[] PojedynczyRuch(string struktura)
        {
            string[] bufor = struktura.Split(' ');
            return bufor;
        }
        public static string[] ZaladujListe(string struktura)
        {
            string[] bufor = struktura.Split(' ');
            int NumberOfMoves = (int)bufor.GetLongLength(0);
            int nieparzysta = NumberOfMoves % 2;
            string[] ruchy = new string[NumberOfMoves + nieparzysta];

            for (int i = 0; i < NumberOfMoves; i += 2)
            {
                ruchy[i] = bufor[i];
                int len = (int)ruchy[i].Length;
                for (int y = 0; y < 15 - len; y++)
                {
                    ruchy[i] += "  ";
                }
                if ((i + 1) < NumberOfMoves)
                {
                    ruchy[i] += bufor[i + 1];
                }
            }

            return ruchy;
        }
        public static ObservableCollection<string> ZbudujListe(string[] tab)
        {
            ObservableCollection<string> budowana = new ObservableCollection<string>();
            for (int i = 0; i < tab.Length; i++)
            {
                budowana.Add(tab[i]);
            }
            return budowana;
        }
    }
}