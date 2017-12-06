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

        public Lid GetLidFromId(int lidId)
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
                                    Persoon persoon = GetPersoonFromLidId(reader.GetInt32(2));
                                    DateTime lidVanaf = reader.GetDateTime(3);
                                    string _sterren = "";
                                    if (!reader.IsDBNull(4))
                                    {
                                        _sterren = reader.GetString(4);
                                    }
                                    Klasse nhbklasse = null;
                                    if (!reader.IsDBNull(5))
                                    {
                                        nhbklasse = klasseLogic.GetKlasseById(reader.GetInt32(5));
                                    }
                                    Klasse verklasse = klasseLogic.GetKlasseById(reader.GetInt32(6));
                                    Oudercontact oudercontact = null;
                                    if (!reader.IsDBNull(7))
                                    {
                                        oudercontact = oudercontactLogic.GetOudercontactById(reader.GetInt32(7));
                                    }
                                    Bank bank = null;
                                    if (!reader.IsDBNull(8))
                                    {
                                        bank = bankLogic.GetBankById(reader.GetInt32(8));
                                    }
                                    Lid lid = new Lid(lidVanaf, nhbklasse, verklasse, id, bondsnummer, persoon.Voornaam,
                                        persoon.Tussenvoegsel, persoon.Achternaam, persoon.Emailadres, persoon.Geslacht,
                                        persoon.Geboortedatum, persoon.Adres, persoon.Telefoonnummer, persoon.Mobielnummer);
                                    lid.SetOuderContact(oudercontact);
                                    lid.SetBank(bank);
                                    lid.SetTypes(GetLidTypesFromId(lid.Id));
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
                                    int bondsnummer = 0;
                                    if (!reader.IsDBNull(1))
                                    {
                                        bondsnummer = reader.GetInt32(1);
                                    }
                                    Persoon persoon = GetPersoonFromLidId(reader.GetInt32(2));
                                    DateTime lidVanaf = reader.GetDateTime(3);
                                    string _sterren = "";
                                    if (!reader.IsDBNull(4))
                                    {
                                        _sterren = reader.GetString(4);
                                    }
                                    Klasse nhbklasse = null;
                                    if (!reader.IsDBNull(5))
                                    {
                                        nhbklasse = klasseLogic.GetKlasseById(reader.GetInt32(5));
                                    }

                                    Klasse clubklasse = klasseLogic.GetKlasseById(reader.GetInt32(6));
                                    Oudercontact oudercontact = null;
                                    if (!reader.IsDBNull(7))
                                    {
                                        oudercontact = oudercontactLogic.GetOudercontactById(reader.GetInt32(7));
                                    }
                                    Bank bank = null;
                                    if (!reader.IsDBNull(8))
                                    {
                                        bank = bankLogic.GetBankById(reader.GetInt32(8));
                                    }
                                    Lid lid = new Lid(lidVanaf, nhbklasse, clubklasse, id, bondsnummer, persoon.Voornaam,
                                        persoon.Tussenvoegsel, persoon.Achternaam, persoon.Emailadres, persoon.Geslacht,
                                        persoon.Geboortedatum, persoon.Adres, persoon.Telefoonnummer, persoon.Mobielnummer);
                                    lid.SetOuderContact(oudercontact);
                                    lid.SetBank(bank);
                                    lid.SetTypes(GetLidTypesFromId(lid.Id));
                                    if (_sterren != "")
                                    {
                                        string[] sterren = _sterren.Split(';');
                                        foreach (string s in sterren)
                                        {
                                            lid.AddSpeld(s);
                                        }
                                    }
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

        public List<Lid> GetPersonenFromLidVanaf()
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
                            cmd.CommandText = "SELECT * FROM Lid LEFT JOIN Persoon ON LPersoonId = PId ORDER BY LLidVanaf DESC;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                int id = reader.GetInt32(0);
                                int bondsnummer = 0;
                                if (!reader.IsDBNull(1))
                                {
                                    bondsnummer = reader.GetInt32(1);
                                }
                                Persoon persoon = GetPersoonFromLidId(reader.GetInt32(2));
                                DateTime lidVanaf = reader.GetDateTime(3);
                                string _sterren = "";
                                if (!reader.IsDBNull(4))
                                {
                                    _sterren = reader.GetString(4);
                                }
                                Klasse nhbklasse = null;
                                if (!reader.IsDBNull(5))
                                {
                                    nhbklasse = klasseLogic.GetKlasseById(reader.GetInt32(5));
                                }

                                Klasse clubklasse = klasseLogic.GetKlasseById(reader.GetInt32(6));
                                Oudercontact oudercontact = null;
                                if (!reader.IsDBNull(7))
                                {
                                    oudercontact = oudercontactLogic.GetOudercontactById(reader.GetInt32(7));
                                }
                                Bank bank = null;
                                if (!reader.IsDBNull(8))
                                {
                                    bank = bankLogic.GetBankById(reader.GetInt32(8));
                                }
                                Lid lid = new Lid(lidVanaf, nhbklasse, clubklasse, id, bondsnummer, persoon.Voornaam,
                                    persoon.Tussenvoegsel, persoon.Achternaam, persoon.Emailadres, persoon.Geslacht,
                                    persoon.Geboortedatum, persoon.Adres, persoon.Telefoonnummer, persoon.Mobielnummer);
                                lid.SetOuderContact(oudercontact);
                                lid.SetBank(bank);
                                lid.SetTypes(GetLidTypesFromId(lid.Id));
                                if (_sterren != "")
                                {
                                    string[] sterren = _sterren.Split(';');
                                    foreach (string s in sterren)
                                    {
                                        lid.AddSpeld(s);
                                    }
                                }
                                leden.Add(lid);
                            }
                            return leden;
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
                int persoonId = addPersoon(lid);
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "INSERT INTO Lid VALUES (@bondsnummer, @persoonId, @lidvanaf, @sterren, @nhbklasse, @klasse, @oudercontactId, @bankId);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bondsnummer", lid.Bondsnummer);
                            cmd.Parameters.AddWithValue("@persoonId", persoonId);
                            cmd.Parameters.AddWithValue("@lidvanaf", lid.LidVanaf);
                            cmd.Parameters.AddWithValue("@sterren", lid.GetSpelden());
                            cmd.Parameters.AddWithValue("@nhbklasse", lid.NhbKlasse.Id);
                            cmd.Parameters.AddWithValue("@klasse", lid.Klasse.Id);
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

        public Persoon GetPersoonFromLidId(int persoonId)
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
                            cmd.CommandText = "SELECT * FROM Persoon WHERE PId = @persoonId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@persoonId", persoonId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string voornaam = reader.GetString(1);
                                    string tussenvoegsel = "";
                                    if (!reader.IsDBNull(2))
                                    {
                                        tussenvoegsel = reader.GetString(2);
                                    }
                                    string achternaam = reader.GetString(3);
                                    string emailadres = "";
                                    if (!reader.IsDBNull(4))
                                    {
                                        emailadres = reader.GetString(4);
                                    }
                                    string geslacht = reader.GetString(5);
                                    Adres adres = adresLogic.GetAdresById(reader.GetInt32(6));
                                    string telefoonnummer = "";
                                    if (!reader.IsDBNull(7))
                                    {
                                        telefoonnummer = reader.GetString(7);
                                    }
                                    string mobielnummer = "";
                                    if (!reader.IsDBNull(8))
                                    {
                                        mobielnummer = reader.GetString(8);
                                    }
                                    DateTime geboortedatum = reader.GetDateTime(9);

                                    Persoon persoon = new Persoon(id, voornaam, tussenvoegsel, achternaam, emailadres, geslacht, geboortedatum, adres, telefoonnummer, mobielnummer);
                                    return persoon;
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

        // Voordat een Lid toegevoegd kan worden, moet een Persoon worden toegevoegd.
        // Returnt het id van de persoon
        private int addPersoon(Lid lid)
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
                            cmd.CommandText = "INSERT INTO Persoon VALUES(@Voornaam, @Tussenvoegsel, @Achternaam, @Emailadres, @Geslacht, @AdresId, @Telefoonnummer, @Mobielnummer, @Geboortedatum);";
                            cmd.Connection = conn;

                            // parameters moeten nog komen
                            cmd.Parameters.AddWithValue("@Voornaam", lid.Voornaam);
                            cmd.Parameters.AddWithValue("@Tussenvoegsel", lid.GetTelefoonnummer());
                            cmd.Parameters.AddWithValue("@Achternaam", lid.Achternaam);
                            cmd.Parameters.AddWithValue("@Emailadres", lid.GetEmailadres());
                            cmd.Parameters.AddWithValue("@Geslacht", lid.GetGeslacht());
                            cmd.Parameters.AddWithValue("@AdresId", lid.Adres.Id);
                            cmd.Parameters.AddWithValue("@Telefoonnummer", lid.GetTelefoonnummer());
                            cmd.Parameters.AddWithValue("@Mobielnummer", lid.GetMobielnummer());
                            cmd.Parameters.AddWithValue("@Geboortedatum", lid.Geboortedatum);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT PId FROM Persoon ORDER BY PId DESC;";

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int id = reader.GetInt32(0);
                                return id;
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private LidType GetLidTypeFromId(int typeId)
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
                            cmd.CommandText = "SELECT * FROM Type WHERE TypeId = @Id;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@Id", typeId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    bool bestuur = reader.GetBoolean(2);
                                    bool commissie = reader.GetBoolean(3);

                                    LidType soort = new LidType(id, name, bestuur, commissie);
                                    return soort;
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

        public List<LidType> GetAllLidTypes()
        {
            try
            {
                List<LidType> soorten = new List<LidType>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Type;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    bool bestuur = reader.GetBoolean(2);
                                    bool commissie = reader.GetBoolean(3);

                                    LidType soort = new LidType(id, name, bestuur, commissie);
                                    soorten.Add(soort);
                                }
                                return soorten;
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

        private List<LidType> GetLidTypesFromId(int lidId)
        {
            try
            {
                List<LidType> soorten = new List<LidType>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT TypeID, TypeNaam, TypeBestuur, TypeCommissie FROM Type JOIN LidType ON LtTypeId = TypeId JOIN Lid ON LId = LtLidId WHERE LId = @lidId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@lidId", lidId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    bool bestuur = reader.GetBoolean(2);
                                    bool commissie = reader.GetBoolean(3);

                                    LidType soort = new LidType(id, name, bestuur, commissie);
                                    soorten.Add(soort);
                                }
                                return soorten;
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
    }
}
