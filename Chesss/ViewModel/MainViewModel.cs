using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chesss.ViewModel
{
    using BaseClass;
    using Chesss.Model;
    using System.Collections.ObjectModel;
    using System.Windows;

    class MainViewModel : BaseViewModel
    {
        private Pola Pola = new Pola();
        private string[] moves;
        private string[] pojruch;
        private int indeks;
        private int ile;

        public ObservableCollection<Rozgrywki> AllMatches = new ObservableCollection<Rozgrywki>();
        public ObservableCollection<Szachisci> AllSzach = new ObservableCollection<Szachisci>();
    

        public ObservableCollection<sbyte> ListaId;
        public MainViewModel()
        {
            indeks = 0;
            ile = 0;
            Field = Pola.Pole;

            AllMatches = Rozgrywki.PobierzWszystkieRozgrywki();
            AllSzach = Szachisci.PobierzWszystkichSzachistow();
            ListaId = Skladanie.ZbierzID(AllMatches);
            ListOfMatches = Skladanie.Zloz(AllSzach, AllMatches);

            try
            {
                pojruch = ListaRuchow.PojedynczyRuch(Skladanie.AktualnaGra(AllMatches, ListaId, int.Parse(SelectIndex)));
                Moves = ListaRuchow.ZaladujListe(Skladanie.AktualnaGra(AllMatches, ListaId, int.Parse(SelectIndex)));
                Zwyciezca = Skladanie.Zwyciezyl(AllMatches, ListaId, int.Parse(SelectIndex));
                Lista = ListaRuchow.ZbudujListe(moves);
                ile = pojruch.Length;
                Pola = new Pola();
                Field = Pola.Pole;
            }
            catch (System.ArgumentOutOfRangeException) { }
        }

        public string[] Moves
        {
            get { return moves; }
            set { moves = value; onPropertyChanged(nameof(Moves)); }
        }
        private ObservableCollection<string> field = new ObservableCollection<string>();
        public ObservableCollection<string> Field
        {
            get { return field; }
            set { field = value; onPropertyChanged(nameof(Field)); }
        }
        private ICommand next;
        public ICommand Next
        {
            get
            {
                if (next == null)
                {
                    next = new RelayCommand(
                        arg =>
                        {
                            Field = Pola.Przestaw(pojruch[indeks], true);
                            if (Field[4] == "ckc.png" && indeks == 0)
                            {
                                MessageBox.Show("Zły format tekstu.");
                                indeks = 0;
                            }
                            else
                            {
                                indeks++;
                                if (indeks == ile) MessageBox.Show($"Koniec partii\n Zwycięzca: {Zwyciezca}");
                            }
                        },
                        arg => indeks < ile);
                }
                return next;
            }
        }
        private ICommand previous;
        public ICommand Previous
        {
            get
            {
                if (previous == null)
                {
                    previous = new RelayCommand(
                        arg =>
                        {
                            indeks--;
                            Field = Pola.Przestaw(pojruch[indeks], false);
                        },
                        arg => indeks > 0);
                }
                return previous;
            }
        }

        private string selectIndex = "0";
        public string SelectIndex
        {
            get { return selectIndex; }
            set
            {
                selectIndex = value;
                onPropertyChanged(nameof(SelectIndex));
            }
        }
        private string moveIndeks = "0";
        public string MoveIndeks
        {
            get { return moveIndeks; }
            set
            {
                moveIndeks = value;
                onPropertyChanged(nameof(MoveIndeks));
            }
        }

        private string zwyciezca;
        public string Zwyciezca
        {
            get { return zwyciezca; }
            set
            {
                zwyciezca = value;
                onPropertyChanged(nameof(Zwyciezca));
            }
        }

        private ICommand zmienGre;
        public ICommand ZmienGre
        {
            get
            {
                if (zmienGre == null)
                {
                    zmienGre = new RelayCommand(
                        arg =>
                        {
                            int num = int.Parse((string)arg);
                            pojruch = ListaRuchow.PojedynczyRuch(Skladanie.AktualnaGra(AllMatches, ListaId, num));
                            Moves = ListaRuchow.ZaladujListe(Skladanie.AktualnaGra(AllMatches, ListaId, num));
                            Zwyciezca = Skladanie.Zwyciezyl(AllMatches, ListaId, num);
                            Lista = ListaRuchow.ZbudujListe(moves);
                            ile = pojruch.Length;
                            Pola = new Pola();
                            Field = Pola.Pole;
                            indeks = 0;
                        },
                        arg => true);
                }
                return zmienGre;
            }
        }
        //private ICommand zmienRuch;
        //public ICommand ZmienRuch
        //{
        //    get
        //    {
        //        if (zmienRuch == null)
        //        {
        //            zmienRuch = new RelayCommand(
        //                arg =>
        //                {
        //                    int num = int.Parse((string)arg);
        //                    if(num * 2 > indeks)
        //                    {
        //                        for(int i = 0;i < (num * 2 - indeks) + 1;i++)
        //                        {
        //                            Field = Pola.Przestaw(pojruch[indeks], true);
        //                            indeks++;
        //                            if (indeks == ile) MessageBox.Show($"Koniec partii\n Zwycięzca: {Zwyciezca}");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        for(int i = 0;i < (indeks - (num * 2));i++)
        //                        {
        //                            indeks--;
        //                            Field = Pola.Przestaw(pojruch[indeks], false);
        //                        }
        //                    }
        //                },
        //                arg => true);
        //        }
        //        return zmienRuch;
        //    }
        //}

        private ObservableCollection<string> listOfMatches;
        public ObservableCollection<string> ListOfMatches
        {
            get { return listOfMatches; }
            set
            {
                listOfMatches = value;
                onPropertyChanged(nameof(ListOfMatches));
            }
        }
        private ObservableCollection<string> lista;
        public ObservableCollection<string> Lista
        {
            get { return lista; }
            set
            {
                lista = value;
                onPropertyChanged(nameof(Lista));
            }
        }
    }
}