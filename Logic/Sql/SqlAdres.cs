using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Interfaces;
using Logic.Classes;

namespace Logic.Sql
{
    public class SqlAdres : IAdresServices
    {
        private string connectie;

        public SqlAdres(string connectie)
        {
            this.connectie = connectie;
        }
        public Adres GetAdresById(int adresId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Adres WHERE AdresId = @adresId;";
                            cmd.Connection = conn;
                            

                            cmd.Parameters.AddWithValue("@adresId", adresId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string straat = reader.GetString(1);
                                    string huisnummer = reader.GetString(2);
                                    string postcode = reader.GetString(3);
                                    string woonplaats = reader.GetString(4);
                                    string huisemail = "";
                                    if (!reader.IsDBNull(5))
                                    {
                                        huisemail = reader.GetString(5);
                                    }
                                    Adres adres = new Adres(id, straat, huisnummer, postcode, woonplaats);
                                    return adres;
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Adres> GetAdressenByCity(string city)
        {
            try
            {
                List<Adres> adressen = new List<Adres>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", city);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Adres> GetAdresByPostcode(string postcode)
        {
            try
            {
                List<Adres> adressen = new List<Adres>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", postcode);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {

                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void AddAdres(Adres adres)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "INSERT INTO Adres (AdresStraatnaam, AdresHuisnummer, AdresPostcode, AdresWoonplaats, AdresEmailadres) VALUES (@straatnaam, @huisnummer, @postcode, @woonplaats, @emailadres);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@straatnaam", adres.Straatnaam);
                            cmd.Parameters.AddWithValue("@huisnummer", adres.Huisnummer);
                            cmd.Parameters.AddWithValue("@postcode", adres.Postcode);
                            cmd.Parameters.AddWithValue("@woonplaats", adres.Plaats);
                            cmd.Parameters.AddWithValue("@emailadres", adres.Emailadres);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void EditAdres(Adres adres)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", adres);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void RemoveAdres(Adres adres)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", adres);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
