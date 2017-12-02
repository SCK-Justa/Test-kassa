using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlOudercontact : IOuderContactServices
    {
        private string connectie;
        public SqlOudercontact(string connectie)
        {
            this.connectie = connectie;
        }
        public Oudercontact GetOudercontactById(int id)
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
                            cmd.CommandText = "SELECT * FROM Oudercontact WHERE OcId = @oudercontactId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@oudercontactId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int ocId = reader.GetInt32(0);
                                string voornaam = reader.GetString(1);
                                string tussenvoegsel = "";
                                if (reader.IsDBNull(2))
                                {
                                    tussenvoegsel = reader.GetString(2);
                                }
                                string achternaam = reader.GetString(3);
                                string tel1 = reader.GetString(4);
                                string tel2 = "";
                                if (reader.IsDBNull(5))
                                {
                                    tel2 = reader.GetString(5);
                                }
                                string email1 = reader.GetString(6);
                                string email2 = "";
                                if (reader.IsDBNull(7))
                                {
                                    email2 = reader.GetString(7);
                                }

                                Oudercontact oc = new Oudercontact(ocId, voornaam, tussenvoegsel, achternaam, tel1, tel2, email1, email2);
                                return oc;
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

        public List<Oudercontact> GetOudercontacten()
        {
            throw new System.NotImplementedException();
        }

        public Oudercontact AddOudercontact(Oudercontact contact)
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
                            cmd.CommandText = "INSERT INTO Oudercontact VALUES (@voornaam, @tussen, @achternaam, @tel1, @tel2, @email1, @email2);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@voornaam", contact.Voornaam);
                            cmd.Parameters.AddWithValue("@tussen", contact.Tussenvoegsel);
                            cmd.Parameters.AddWithValue("@achternaam", contact.Achternaam);
                            cmd.Parameters.AddWithValue("@tel1", contact.Telefoonnummer1);
                            cmd.Parameters.AddWithValue("@tel2", contact.Telefoonnummer2);
                            cmd.Parameters.AddWithValue("@email1", contact.Emailadres1);
                            cmd.Parameters.AddWithValue("@email2", contact.Emailadres2);

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT OcId FROM Oudercontact ORDER BY OcId DESC;";
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    return GetOudercontactById(id);
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

        public void EditOudercontact(Oudercontact contact)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveOudercontact(Oudercontact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
