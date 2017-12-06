using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlAuthentication : IAuthenticationServices
    {
        private string connectie;
        private SqlLid sqllid;
        public SqlAuthentication(string connectie)
        {
            this.connectie = connectie;
            sqllid = new SqlLid(connectie);
        }
        public bool CheckLogin(string gebruikersnaam, string wachtwoord)
        {
            throw new NotImplementedException();
        }

        public int GetPersoonIdFromLogin(string gebruikersnaam, string wachtwoord)
        {
            throw new NotImplementedException();
        }

        public Authentication GetAuthenticationFromId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Authentication> GetAuthentications()
        {
            try
            {
                List<Authentication> authentications = new List<Authentication>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Authenticatie;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    string wachtwoord = reader.GetString(2);
                                    int kassaId = reader.GetInt32(3);
                                    Lid lid = sqllid.GetLidFromId(reader.GetInt32(4));

                                    Authentication auth = new Authentication(id, name, wachtwoord, lid, kassaId);
                                    authentications.Add(auth);
                                }
                                return authentications;
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

        public void AddAuthentication(Authentication authentication)
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
                            cmd.CommandText = "INSERT INTO Authenticatie (AuthGebruikersnaam, AuthWachtwoord, AuthKassaId, AuthLidId) VALUES (@gebruikersnaam, @wachtwoord, @kassaId, @lidId);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@gebruikersnaam", authentication.Username);
                            cmd.Parameters.AddWithValue("@wachtwoord", authentication.Password);
                            cmd.Parameters.AddWithValue("@kassaId", authentication.KassaId);
                            cmd.Parameters.AddWithValue("@lidId", authentication.Lid.Id);

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

        public void EditAuthentication(Authentication authentication)
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
                            cmd.CommandText = "UPDATE Authenticatie SET AuthGebruikersnaam = @gebruikersnaam, AuthWachtwoord = @wachtwoord WHERE AuthLidId = @lidId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@gebruikersnaam", authentication.Username);
                            cmd.Parameters.AddWithValue("@wachtwoord", authentication.Password);
                            cmd.Parameters.AddWithValue("@lidId", authentication.Lid.Id);

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

        public void RemoveAuthentication(Authentication authentication)
        {
            throw new NotImplementedException();
        }
    }
}
