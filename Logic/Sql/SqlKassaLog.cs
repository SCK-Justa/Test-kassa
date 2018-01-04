using System;
using Logic.Classes.Enums;
using Logic.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Logic.Sql
{
    public class SqlKassaLog : IKassaLogServices
    {
        private string connectie;

        public SqlKassaLog(string conn)
        {
            connectie = conn;
        }
        public void AddLogString(int kassaId, string log, KassaSoortEnum soort)
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
                            cmd.CommandText = "INSERT INTO KassaLog (KlKassaId, KlOmschrijving, KlSoort) VALUES(@kassaId, @log, @soort);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@kassaId", kassaId);
                            cmd.Parameters.AddWithValue("@log", log);
                            cmd.Parameters.AddWithValue("@soort", soort);

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

        public List<string> GetKassaLog()
        {
            try
            {
                List<string> log = new List<string>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM KassaLog;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    int kassaId = reader.GetInt32(1);
                                    string logString = reader.GetString(2);
                                    KassaSoortEnum soort =
                                        (KassaSoortEnum) Enum.Parse(typeof(KassaSoortEnum), reader.GetString(3));
                                    log.Add(soort + ", " + logString);
                                }
                                return log;
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
