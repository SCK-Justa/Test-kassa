using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlOmzet : IOmzetServices
    {
        private string connectie;
        List<decimal> omzet;
        public SqlOmzet(string dbConnectie)
        {
            connectie = dbConnectie;
        }
        public decimal GetOmzetPerDag(DateTime datum)
        {
            try
            {
                decimal totaalBedrag = 0;
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT SUM(BBetaaldBedrag) FROM Bestelling WHERE BBetalld = 1 AND BDatumBetaald >= @beginDag AND BDatumBetaald <= @eindDag;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@beginDag", datum);
                            datum = datum.AddDays(1);
                            cmd.Parameters.AddWithValue("@eindDag", datum);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    decimal totaal = 0;
                                    if (!reader.IsDBNull(0))
                                    {
                                        totaal = reader.GetDecimal(0);
                                    }
                                    totaalBedrag = totaal;
                                }
                                return totaalBedrag;
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

        public List<decimal> GetOmzetPerWeek(DateTime eerstedagvandemaand)
        {
            throw new System.NotImplementedException();
        }

        public List<decimal> GetOmzetPerMaand(DateTime jaartal)
        {
            throw new System.NotImplementedException();
        }

        public decimal GetOmzetPerJaar(DateTime jaar)
        {
            try
            {
                omzet = new List<decimal>();
                //DateTime firstDay = new DateTime(jaar.Year, 1, 1);
                //DateTime lastDay = new DateTime(jaar.Year + 1, 1, 1);

                string firstDay = jaar.Year + "-1-1";
                string lastDay = (jaar.Year + 1) + "-1-1";
                Console.WriteLine(firstDay);
                Console.WriteLine(lastDay);

                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT SUM(BBetaaldBedrag) FROM Bestelling WHERE BDatumBetaald >= @firstDate AND BDatumBetaald <= @lastDate;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@firstDate", firstDay);
                            cmd.Parameters.AddWithValue("@lastDate", lastDay);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                return reader.GetDecimal(0);
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SetBedragInKas(decimal bedrag)
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
                            cmd.CommandText = "UPDATE Kassa SET KassaInhoud = @bedrag WHERE KassaId = 0;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bedrag", bedrag);

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
