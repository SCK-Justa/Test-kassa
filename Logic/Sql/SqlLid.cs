using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Interfaces;
using Logic.Classes;

namespace Logic.Sql
{
    public class SqlLid : ILidServices
    {
        private string connectie;
        private SqlAdres adresLogic;
        private SqlKlasse klasseLogic;
        private SqlBank bankLogic;
        private SqlOudercontact oudercontactLogic;

        public SqlLid(string connectie)
        {
            this.connectie = connectie;
            adresLogic = new SqlAdres(connectie);
            klasseLogic = new SqlKlasse(connectie);
            bankLogic = new SqlBank(connectie);
            oudercontactLogic = new SqlOudercontact(connectie);
        }

        public Lid GetPersoonFromId(int lidId)
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
                            cmd.CommandText = "SELECT * FROM Lid WHERE LId = @lidId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@lidId", lidId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    int bondsnummer = 0;
                                    if (!reader.IsDBNull(1))
                                    {
                                        bondsnummer = reader.GetInt32(1);
                                    }
                                    string voornaam = reader.GetString(2);
                                    string tussenvoegsel = "";
                                    if (!reader.IsDBNull(2))
                                    {
                                        tussenvoegsel = reader.GetString(3);
                                    }
                                    string achternaam = reader.GetString(4);
                                    string emailadres = "";
                                    if (!reader.IsDBNull(5))
                                    {
                                        emailadres = reader.GetString(5);
                                    }
                                    string geslacht = "";
                                    if (!reader.IsDBNull(6))
                                    {
                                        geslacht = reader.GetString(6);
                                    }
                                    Adres adres = adresLogic.GetAdresById(reader.GetInt32(7));
                                    string telefoonnummer = "";
                                    if (!reader.IsDBNull(8))
                                    {
                                        telefoonnummer = reader.GetString(8);
                                    }
                                    string mobielnummer = "";
                                    if (!reader.IsDBNull(9))
                                    {
                                        mobielnummer = reader.GetString(9);
                                    }
                                    DateTime lidvanaf = reader.GetDateTime(10);
                                    string _sterren = "";
                                    if (!reader.IsDBNull(11))
                                    {
                                        _sterren = reader.GetString(11);
                                    }
                                    DateTime geboortedatum = reader.GetDateTime(12);
                                    Klasse nhbklasse = null;
                                    if (!reader.IsDBNull(13))
                                    {
                                        nhbklasse = klasseLogic.GetKlasseById(reader.GetInt32(13));
                                    }
                                    Klasse verklasse = klasseLogic.GetKlasseById(reader.GetInt32(14));
                                    Oudercontact oudercontact = null;
                                    if (!reader.IsDBNull(15))
                                    {
                                        oudercontact = oudercontactLogic.GetOudercontactById(reader.GetInt32(15));
                                    }
                                    Bank bank = null;
                                    if (!reader.IsDBNull(16))
                                    {
                                        bank = bankLogic.GetBankById(reader.GetInt32(16));
                                    }
                                    Lid lid = new Lid(lidvanaf, nhbklasse, verklasse, id, bondsnummer, voornaam, tussenvoegsel, achternaam, emailadres,
                                                        geslacht, geboortedatum, adres, telefoonnummer, mobielnummer);
                                    lid.SetOuderContact(oudercontact);
                                    lid.SetBank(bank);
                                    if (_sterren != "")
                                    {
                                        string[] sterren = _sterren.Split(';');
                                        foreach (string s in sterren)
                                        {
                                            lid.AddSpeld(s);
                                        }
                                    }
                                    return lid;
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

        public Lid GetPersoonFromBondsnummer(int bondsnummer)
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

                            cmd.Parameters.AddWithValue("@", bondsnummer);

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

        public Lid GetPersoonFromFullName(string firstname, string lastname)
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

                            cmd.Parameters.AddWithValue("@", firstname);

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

        public List<Lid> GetAllLeden()
        {
            try
            {
                List<Lid> leden = new List<Lid>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Lid;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    int bondsnummer = reader.GetInt32(1);
                                    string voornaam = reader.GetString(2);
                                    string tussenvoegsel = reader.GetString(3);
                                    string achternaam = reader.GetString(4);
                                    string emailadres = "";
                                    string geslacht = "";
                                    if (!reader.IsDBNull(5))
                                    {
                                        emailadres = reader.GetString(5);
                                    }
                                    if (!reader.IsDBNull(6))
                                    {
                                        geslacht = reader.GetString(6);
                                    }
                                    Adres adres = adresLogic.GetAdresById(reader.GetInt32(7));
                                    string telefoonnummer = "";
                                    string mobielnummer = "";
                                    if (!reader.IsDBNull(8))
                                    {
                                        telefoonnummer = reader.GetString(8);
                                    }
                                    if (!reader.IsDBNull(9))
                                    {
                                        mobielnummer = reader.GetString(9);
                                    }
                                    DateTime lidVanaf = reader.GetDateTime(10);
                                    string sterren = "";
                                    if (!reader.IsDBNull(11))
                                    {
                                        sterren = reader.GetString(11);
                                    }
                                    DateTime geboorteDatum = reader.GetDateTime(12);
                                    Klasse nhbklasse = null;
                                    if (!reader.IsDBNull(13))
                                    {
                                        nhbklasse = klasseLogic.GetKlasseById(reader.GetInt32(13));
                                    }

                                    Klasse clubklasse = klasseLogic.GetKlasseById(reader.GetInt32(14));

                                    Lid lid = new Lid(lidVanaf, nhbklasse, clubklasse, id, bondsnummer, voornaam,
                                        tussenvoegsel, achternaam, emailadres, geslacht,
                                        geboorteDatum, adres, telefoonnummer, mobielnummer);
                                    leden.Add(lid);
                                }
                                return leden;
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

        public List<Lid> GetPersonenFromDateOfBirth(DateTime dateOfBirth)
        {
            try
            {
                List<Lid> leden = new List<Lid>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", dateOfBirth);

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

        public List<Lid> GetPersonenFromLidVanaf(DateTime dateVanaf)
        {
            try
            {
                List<Lid> leden = new List<Lid>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = ";";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@", dateVanaf);

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

        public void AddPersoon(Lid lid)
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
                            cmd.CommandText = "INSERT INTO Lid VALUES (@bondsnummer, @voornaam, @tussenvoegsel, @achternaam, @email, @geslacht, @adresId, " +
                                              "@telefoonnummer, @mobiel, @lidvanaf, @sterren, @geboortedatum, @nhbklasse, @klasse, @oudercontactId, @bankId);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bondsnummer", lid.Bondsnummer);
                            cmd.Parameters.AddWithValue("@voornaam", lid.Bondsnummer);
                            cmd.Parameters.AddWithValue("@tussenvoegsel", lid.Bondsnummer);
                            cmd.Parameters.AddWithValue("@achternaam", lid.Achternaam);
                            cmd.Parameters.AddWithValue("@email", lid.Emailadres);
                            cmd.Parameters.AddWithValue("@geslacht", lid.Geslacht);
                            cmd.Parameters.AddWithValue("@adresId", lid.Adres.Id);
                            cmd.Parameters.AddWithValue("@telefoonnummer", lid.Telefoonnummer);
                            cmd.Parameters.AddWithValue("@mobiel", lid.Mobielnummer);
                            cmd.Parameters.AddWithValue("@lidvanaf", lid.LidVanaf);
                            cmd.Parameters.AddWithValue("@sterren", lid.GetSpelden());
                            cmd.Parameters.AddWithValue("@geboortedatum", lid.Geboortedatum);
                            cmd.Parameters.AddWithValue("@nhbklasse", lid.NhbKlasse);
                            cmd.Parameters.AddWithValue("@klasse", lid.Klasse);
                            cmd.Parameters.AddWithValue("@oudercontactid", lid.Oudercontact.Id);
                            cmd.Parameters.AddWithValue("@bankId", lid.Bank.Id);

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

        public void EditPersoon(Lid lid)
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

                            cmd.Parameters.AddWithValue("@", lid);

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

        public void RemovePersoon(Lid lid)
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

                            cmd.Parameters.AddWithValue("@", lid);

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
