using System;
using System.Collections.Generic;
using Logic.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Logic.Sql
{
    public class SqlLedenLog : ILedenLogServices
    {
        private string connectie;
        public SqlLedenLog(string conn)
        {
            connectie = conn;
        }
        public void AddLogString(string description, bool join, bool leave)
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
                            cmd.CommandText = "INSERT INTO LedenLog VALUES(@description, @join, @leave);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@join", join);
                            cmd.Parameters.AddWithValue("@leave", leave);

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

        public List<string> GetLedenLog()
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
                            cmd.CommandText = "SELECT * FROM LedenLog;";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string logString = "";
                                    string description = reader.GetString(1);
                                    bool join = reader.GetBoolean(2);
                                    bool leave = reader.GetBoolean(3);
                                    if (join)
                                    {
                                        // Pietje is op 01-01-2018 lid geworden van Sint Sebastiaan.
                                        logString = description + " lid geworden van Sint Sebastiaan.";
                                    }
                                    if (leave)
                                    {
                                        // Pietje heeft zich op 01-07-2018 uitgeschreven als lid.
                                        logString = description + " uitgeschreven als lid.";
                                    }
                                    log.Add(logString);
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
