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
                            cmd.CommandText = "SELECT * FROM Klasse WHERE KlasseId = @id;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@id", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int klasseId = reader.GetInt32(0);
                                    string naam = reader.GetString(1);
                                    int begin = reader.GetInt32(2);
                                    int eind = reader.GetInt32(3);

                                    Klasse klasse = new Klasse(klasseId, naam, begin, eind);
                                    return klasse;
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

        public List<Klasse> GetKlasses()
        {
            try
            {
                List<Klasse> klasses = new List<Klasse>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Klasse;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                Klasse klasse;
                                while (reader.Read())
                                {
                                    int klasseId = reader.GetInt32(0);
                                    string naam = reader.GetString(1);
                                    int begin = reader.GetInt32(2);
                                    int eind = reader.GetInt32(3);

                                    klasse = new Klasse(klasseId, naam, begin, eind);
                                    klasses.Add(klasse);
                                }
                                return klasses;
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
