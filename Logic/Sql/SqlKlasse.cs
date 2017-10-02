using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlKlasse : IKlasseServices
    {
        private string connectie;
        public SqlKlasse(string connectie)
        {
            this.connectie = connectie;
        }
        public Klasse GetKlasseById(int id)
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
                            cmd.CommandText = "SELECT * FROM Klasse WHERE KlasseId = @lidId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@lidId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int klasseId = reader.GetInt32(0);
                                string naam = reader.GetString(1);
                                DateTime begin = reader.GetDateTime(2);
                                DateTime eind = reader.GetDateTime(3);

                                Klasse klasse = new Klasse(klasseId, naam.Replace(" ", ""), begin, eind);
                                return klasse;
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

        public List<Klasse> GetKlasses()
        {
            throw new NotImplementedException();
        }

        public void AddKlasse(Klasse klasse)
        {
            throw new NotImplementedException();
        }

        public void EditKlasse(Klasse klasse)
        {
            throw new NotImplementedException();
        }

        public void RemoveKlasse(Klasse klasse)
        {
            throw new NotImplementedException();
        }
    }
}
