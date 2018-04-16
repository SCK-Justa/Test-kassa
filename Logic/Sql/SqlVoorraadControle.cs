using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Classes.Enums;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlVoorraadControle : IVoorraadControleServices
    {
        private string connectie;
        private SqlProduct sqlProduct;
        private SqlLid sqlLid;
        public SqlVoorraadControle(string connectie)
        {
            this.connectie = connectie;
            sqlLid = new SqlLid(connectie);
            sqlProduct = new SqlProduct(connectie);
        }

        public List<VoorraadControle> GetVoorraadControles()
        {
            try
            {
                List<VoorraadControle> controles = new List<VoorraadControle>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT VcId, VcProductId, VcDatumControle, VcOudeVoorraad, VcNieuweVoorraad, VcOpmerking " +
                                              "FROM Voorraadcontrolel";
                            cmd.Connection = conn;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    Product product = sqlProduct.GetProductById(reader.GetInt32(1));
                                    Lid controleur = null;
                                    if (!reader.IsDBNull(2))
                                    {
                                        controleur = sqlLid.GetLidFromId(reader.GetInt32(2));
                                    }
                                    DateTime datum = reader.GetDateTime(3);
                                    int oudeVoorraad = reader.GetInt32(4);
                                    int nieuweVoorraad = reader.GetInt32(5);
                                    VoorraadEnum soort =
                                        (VoorraadEnum)Enum.Parse(typeof(VoorraadEnum), reader.GetString(5));
                                    VoorraadControle controle = new VoorraadControle(id, product, controleur, datum, oudeVoorraad, nieuweVoorraad, soort);
                                    controles.Add(controle);
                                }
                                return controles;
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

        public List<VoorraadControle> GetVoorraadControlesFromProduct(Product product)
        {
            try
            {
                List<VoorraadControle> controles = new List<VoorraadControle>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT * FROM VoorraadControle WHERE VcProductId = @productId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@productId", product.Id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                VoorraadControle controle;
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    Lid controleur = null;
                                    if (!reader.IsDBNull(2))
                                    {
                                        controleur = sqlLid.GetLidFromId(reader.GetInt32(2));
                                    }
                                    DateTime datum = reader.GetDateTime(3);
                                    int oudeVoorraad = reader.GetInt32(4);
                                    int nieuweVoorraad = reader.GetInt32(5);
                                    VoorraadEnum soort =
                                        (VoorraadEnum)Enum.Parse(typeof(VoorraadEnum), reader.GetString(6));

                                    controle = new VoorraadControle(id, product, controleur, datum, oudeVoorraad, nieuweVoorraad, soort);
                                    controles.Add(controle);
                                }
                                return controles;
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

        public int AddVoorraadControle(VoorraadControle controle)
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
                            cmd.CommandText = "INSERT INTO VoorraadControle VALUES(@productId, @lidId, @datum, @oud, @nieuw, @opmerking);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@productId", controle.Product.Id);
                            if (controle.Controleur != null)
                            {
                                cmd.Parameters.AddWithValue("@lidId", controle.Controleur.Id);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@lidId", DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@datum", controle.DatumControle);
                            cmd.Parameters.AddWithValue("@oud", controle.OudeVoorraad);
                            cmd.Parameters.AddWithValue("@nieuw", controle.NieuweVoorraad);
                            cmd.Parameters.AddWithValue("@opmerking", controle.Opmerking);

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT VcId FROM VoorraadControle ORDER BY VcId DESC;";
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    return id;
                                }
                            }
                        }
                    }
                }
                return -1;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void ChangeVoorraadControle(VoorraadControle controle, int oudeVoorraad, int nieuweVoorraad)
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
                            cmd.CommandText =
                                "UPDATE VoorraadControle SET VcOudeVoorraad = @oud, VcNieuweVoorraad = @nieuwe WHERE VcId = @id;";
                            cmd.Connection = conn;

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
