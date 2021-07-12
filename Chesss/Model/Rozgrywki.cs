using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Chesss.Model
{
    class Rozgrywki
    {
        public sbyte id { get; set; }
        public sbyte bialy { get; set; }
        public sbyte czarny { get; set; }
        public string miasto { get; set; }
        public int data { get; set; }
        public string partia { get; set; }
        public string debiut { get; set; }
        public string zwyciezca { get; set; }
        public string ruchy { get; set; }

        private const string WSZYSTKIE_ROZGRYWKI = "SELECT * FROM rozgrywki";

        public Rozgrywki(MySqlDataReader reader)
        {
            id = sbyte.Parse(reader["id"].ToString());
            bialy = sbyte.Parse(reader["bialy"].ToString());
            czarny = sbyte.Parse(reader["czarny"].ToString());
            miasto = reader["miasto"].ToString();
            data = int.Parse(reader["data"].ToString());
            partia = reader["partia"].ToString();
            debiut = reader["debiut"].ToString();
            zwyciezca = reader["zwyciezca"].ToString();
            ruchy = reader["ruchy"].ToString();
        }

        public static ObservableCollection<Rozgrywki> PobierzWszystkieRozgrywki()
        {
            ObservableCollection<Rozgrywki> roz = new ObservableCollection<Rozgrywki>();
            using (var connection = DBConnection.Instance.Connection)
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(WSZYSTKIE_ROZGRYWKI, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        roz.Add(new Rozgrywki(reader));
                    connection.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException) { }
            }
            return roz;
        }
    }
}
