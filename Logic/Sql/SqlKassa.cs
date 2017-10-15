using System;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlKassa : IKassaServices
    {
        private string connectie;
        public SqlKassa(string connectie)
        {
            this.connectie = connectie;
        }
        public decimal GetKasInhoud(int kassaId)
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
                            cmd.CommandText = "SELECT KassaInhoud FROM Kassa WHERE KassaId = @kassaId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@kassaId", kassaId);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                decimal inhoud = reader.GetDecimal(0);
                                return inhoud;
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

        public void AddBedragToKas(decimal bedrag)
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
                            cmd.CommandText = "UPDATE Kassa SET KassaInhoud = @bedrag;";
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

        public void RemoveBedragFromKas(decimal bedrag)
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
                            cmd.CommandText = "UPDATE Kassa SET KassaInhoud = @bedrag;";
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
