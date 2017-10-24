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
                                    Lid lid = sqllid.GetLidFromId(reader.GetInt32(5));
                                    AuthenticationSoort soort = GetSoortById(reader.GetInt32(4));
                                    
                                    Authentication auth = new Authentication(id, name, wachtwoord, lid, soort, kassaId);
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
            throw new NotImplementedException();
        }

        public void EditAuthentication(Authentication authentication)
        {
            throw new NotImplementedException();
        }

        public void RemoveAuthentication(Authentication authentication)
        {
            throw new NotImplementedException();
        }

        public AuthenticationSoort GetSoortById(int soortId)
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

                            cmd.Parameters.AddWithValue("@Id", soortId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    bool bestuur = reader.GetBoolean(2);
                                    bool commissie = reader.GetBoolean(3);

                                    AuthenticationSoort soort = new AuthenticationSoort(id, name, bestuur, commissie);
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
    }
}
