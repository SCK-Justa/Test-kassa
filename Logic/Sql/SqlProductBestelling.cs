using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlProductBestelling : IProductenBestellingServices
    {
        private string connectie;

        public SqlProductBestelling(string connectie)
        {
            this.connectie = connectie;
        }
        public void AddProductToBestelling(Bestelling bestelling, Product product)
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
                            cmd.CommandText = "INSERT INTO Productbestelling VALUES (@productId, @bestellingId, @isLid, @datum);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bestellingId", bestelling.Id);
                            cmd.Parameters.AddWithValue("@productId", product.Id);
                            cmd.Parameters.AddWithValue("@isLid", true);
                            cmd.Parameters.AddWithValue("@datum", DateTime.Now);

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

        public LosseVerkoop AddLosseVerkoop(LosseVerkoop verkoop)
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
                            cmd.CommandText = "INSERT INTO Productbestelling VALUES (@productId, @bestellingId, @isLid, @datum);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@productId", verkoop.Id);
                            cmd.Parameters.AddWithValue("@bestellingId", DBNull.Value);
                            cmd.Parameters.AddWithValue("@isLid", verkoop.IsLid);
                            cmd.Parameters.AddWithValue("@datum", verkoop.BestelDatum);

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT PbId FROM Productbestelling ORDER BY PbId DESC";
                            cmd.Connection = conn;

                            using(SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    verkoop.SetLosseVerkoopId(id);
                                    return verkoop;
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

        public void EditProductInBestelling(Bestelling bestelling, Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromBestelling(Bestelling bestelling, Product product)
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
                            cmd.CommandText = "DELETE FROM Productbestelling WHERE PbBestellingId = @bestellingId AND PbProductId = @productId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bestellingId", bestelling.Id);
                            cmd.Parameters.AddWithValue("@productId", product.Id);

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

        public List<LosseVerkoop> GetLosseVerkopen(DateTime beginDate, DateTime endDate)
        { 
            try
            {
                List<LosseVerkoop> productenLosseVerkoop = new List<LosseVerkoop>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT ProdId, ProdNaam, SoortNaam, ProdVoorraad, ProdLedenPrijs, ProdPrijs, PbId, PbIsLid, PbDatum " +
                                "FROM Productbestelling LEFT JOIN Product ON ProdId = PbProductId JOIN Soort ON SoortId = ProdSoortId " +
                                "WHERE PbBestellingId IS NULL AND PbDatum >= @beginDate AND PbDatum <= @endDate;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@beginDate", beginDate);
                            cmd.Parameters.AddWithValue("@endDate", endDate);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int prodId = reader.GetInt32(0);
                                    string prodName = reader.GetString(1);
                                    string prodSoort = reader.GetString(2);
                                    int prodVoorraad = reader.GetInt32(3);
                                    decimal prodLedenPrijs = reader.GetDecimal(4);
                                    decimal prodPrijs = reader.GetDecimal(5);
                                    int pbId = reader.GetInt32(6);
                                    bool isLid;
                                    if(!reader.IsDBNull(7))
                                    {
                                        isLid = reader.GetBoolean(7);
                                    }
                                    else
                                    {
                                        isLid = false;
                                    }
                                    DateTime datumBetaald;
                                    if(!reader.IsDBNull(8))
                                    {
                                        datumBetaald = reader.GetDateTime(8);
                                    }
                                    else
                                    {
                                        datumBetaald = DateTime.Now;
                                    }
                                    LosseVerkoop product = new LosseVerkoop(pbId, datumBetaald, isLid, prodId, prodName, prodSoort, prodVoorraad, prodLedenPrijs, prodPrijs);
                                    productenLosseVerkoop.Add(product);
                                }
                                return productenLosseVerkoop;
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

        public void RemoveProductFromLosseVerkoop(LosseVerkoop verkoop)
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
                            cmd.CommandText = "DELETE FROM Productbestelling WHERE PbId = @pbId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@pbId", verkoop.LosseVerkoopId);

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
