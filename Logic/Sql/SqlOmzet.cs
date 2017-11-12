using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlOmzet : IOmzetServices
    {
        private string connectie;
        public SqlOmzet(string dbConnectie)
        {
            connectie = dbConnectie;
        }
        public List<decimal> GetOmzetPerDag(int weeknr)
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
                            cmd.CommandText = "";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("", weeknr);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                return null;
                throw new Exception(exception.Message);
            }
        }

        public List<decimal> GetOmzetPerWeek(int maand)
        {
            throw new System.NotImplementedException();
        }

        public List<decimal> GetOmzetPerMaand(int jaartal)
        {
            throw new System.NotImplementedException();
        }

        public List<decimal> GetOmzetPerJaar()
        {
            throw new System.NotImplementedException();
        }
    }
}
