using System;
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
                            cmd.CommandText = "INSERT INTO Productbestelling VALUES (@bestellingId, @productId);";
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
    }
}
