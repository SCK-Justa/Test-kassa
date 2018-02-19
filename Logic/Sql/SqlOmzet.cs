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
        public SqlOmzet(string dbConnectie)
        {
            connectie = dbConnectie;
        }
        public decimal GetOmzetPerDag(DateTime datum)
        {
            try
            {
                decimal totaalBedrag = 0;
                DateTime einddatum = datum.AddDays(1);
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT SUM(BBetaaldBedrag) FROM Bestelling WHERE BBetalld = 1 AND BDatumBetaald >= @beginDag AND BDatumBetaald < @eindDag;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@beginDag", datum);
                            cmd.Parameters.AddWithValue("@eindDag", einddatum);

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
                            }
                            totaalBedrag += GetLosseBetalingen(datum, einddatum);
                            return totaalBedrag;
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

        public decimal GetOmzetPerMaand(DateTime begindag, DateTime einddag)
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
                            cmd.CommandText = "SELECT SUM(BBetaaldBedrag) FROM Bestelling WHERE BBetalld = 1 AND BDatumBetaald >= @firstDate AND BDatumBetaald < @lastDate;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@firstDate", begindag);
                            cmd.Parameters.AddWithValue("@lastDate", einddag);

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
                            }
                            totaalBedrag += GetLosseBetalingen(begindag, einddag);
                            return totaalBedrag;
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

        public decimal GetOmzetPerJaar(DateTime jaar)
        {
            try
            {
                decimal totaalBedrag = 0;
                DateTime begindag = new DateTime(jaar.Year, 1, 1);
                DateTime einddag = begindag.AddYears(1);

                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT SUM(BBetaaldBedrag) FROM Bestelling WHERE BBetalld = 1 AND BDatumBetaald >= @firstDate AND BDatumBetaald < @lastDate;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@firstDate", begindag);
                            cmd.Parameters.AddWithValue("@lastDate", einddag);

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
                            }
                            totaalBedrag += GetLosseBetalingen(begindag, einddag);
                            return totaalBedrag;
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

        public decimal GetLosseBetalingen(DateTime begindatum, DateTime einddatum)
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
                            cmd.CommandText = "SELECT PbIsLid, ProdPrijs, ProdLedenPrijs, PbBonnenBetaald FROM Productbestelling LEFT JOIN Product ON ProdId = PbProductId " +
                                "WHERE PbBestellingId IS NULL AND PbDatum BETWEEN @beginDag AND @eindDag;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@beginDag", begindatum);
                            cmd.Parameters.AddWithValue("@eindDag", einddatum);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                decimal totaal = 0;
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        if (reader.GetBoolean(0))
                                        {
                                            if (reader.GetBoolean(3))
                                            {
                                                totaal += 0.00m;
                                            }
                                            else
                                            {
                                                totaal += reader.GetDecimal(2);
                                            }
                                        }
                                        else
                                        {
                                            totaal += reader.GetDecimal(1);
                                        }
                                    }
                                }
                                return totaal;
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
    }
}
