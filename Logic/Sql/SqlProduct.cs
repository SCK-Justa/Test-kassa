using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlProduct : IProductServices
    {
        private string connectie;
        public SqlProduct(string connectie)
        {
            this.connectie = connectie;
        }

        public Product GetProductByName(string naam)
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
                            cmd.CommandText = "SELECT * FROM Product WHERE PNaam = @prodNaam;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@prodNaam", naam);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int prodId = reader.GetInt32(0);
                                string prodnaam = reader.GetString(1);
                                string soort = reader.GetString(2);
                                int voorraad = reader.GetInt32(3);
                                decimal ledenprijs = reader.GetDecimal(4);
                                decimal prijs = reader.GetDecimal(5);
                                Product product = new Product(prodId, prodnaam, soort, voorraad, ledenprijs, prijs);
                                return product;
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

        public Product GetProductById(int id)
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
                            cmd.CommandText = "SELECT * FROM Product WHERE ProdId = @prodId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@prodId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int prodId = reader.GetInt32(0);
                                string naam = reader.GetString(1);
                                string soort = reader.GetString(2);
                                int voorraad = reader.GetInt32(3);
                                decimal ledenprijs = reader.GetDecimal(4);
                                decimal prijs = reader.GetDecimal(5);
                                Product product = new Product(prodId, naam, soort, voorraad, ledenprijs, prijs);
                                return product;
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

        public List<Product> GetProducten()
        {
            try
            {
                List<Product> producten = new List<Product>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM Product JOIN Soort ON SoortId = ProdSoortId ORDER BY SoortId ASC, ProdNaam ASC;";
                            cmd.Connection = conn;


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int prodId = reader.GetInt32(0);
                                    string naam = reader.GetString(1);
                                    string soort = GetProductSoortName(reader.GetInt32(2));
                                    int voorraad = reader.GetInt32(3);
                                    decimal ledenprijs = reader.GetDecimal(4);
                                    decimal prijs = reader.GetDecimal(5);
                                    Product product = new Product(prodId, naam, soort, voorraad, ledenprijs, prijs);
                                    producten.Add(product);
                                }
                                return producten;
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

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product product)
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
                            cmd.CommandText = "UPDATE Product SET ProdNaam = @prodNaam, ProdVoorraad = @voorraad, ProdLedenPrijs = @ledenprijs, ProdPrijs = @prijs " +
                                              "WHERE ProdId = @prodId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@prodId", product.Id);
                            cmd.Parameters.AddWithValue("@prodNaam", product.Naam);
                            cmd.Parameters.AddWithValue("@voorraad", product.Voorraad);
                            cmd.Parameters.AddWithValue("@ledenprijs", product.Ledenprijs);
                            cmd.Parameters.AddWithValue("@prijs", product.Prijs);

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

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        private string GetProductSoortName(int id)
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
                            cmd.CommandText = "SELECT * FROM Soort WHERE SoortId = @soortId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@soortId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                string name = reader.GetString(1);
                                return name;
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

        public void VoegVoorraadToe(Product product, int hoeveelheid)
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
                            cmd.CommandText = "UPDATE Product SET ProdVoorraad = @hoeveelheid WHERE ProdId = @productId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@productId", product.Id);
                            cmd.Parameters.AddWithValue("@hoeveelheid", hoeveelheid);

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
