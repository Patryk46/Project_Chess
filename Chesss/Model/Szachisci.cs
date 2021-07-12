using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Chesss.Model
{
    class Szachisci
    {
        public sbyte id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string narodowosc { get; set; }
        public string data_urodz { get; set; }

        private const string WSZYSCY_SZACHISCI = "SELECT * FROM szachisci";

        public Szachisci(MySqlDataReader reader)
        {
            id = sbyte.Parse(reader["id"].ToString());
            imie = reader["imie"].ToString();
            nazwisko = reader["nazwisko"].ToString();
            narodowosc = reader["narodowosc"].ToString();
            data_urodz = reader["data_urodzenia"].ToString();
        }

        public static ObservableCollection<Szachisci> PobierzWszystkichSzachistow()
        {
            ObservableCollection<Szachisci> szach = new ObservableCollection<Szachisci>();
            using (var connection = DBConnection.Instance.Connection)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(WSZYSCY_SZACHISCI, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        szach.Add(new Szachisci(reader));
                    connection.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException) { }
            }
            return szach;
        }
    }
}
