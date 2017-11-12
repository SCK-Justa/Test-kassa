﻿using System;
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
        List<decimal> omzet;
        public SqlOmzet(string dbConnectie)
        {
            connectie = dbConnectie;
        }
        public List<decimal> GetOmzetPerDag(DateTime eerstedagvandeweek)
        {
            try
            {
                omzet = new List<decimal>();
                using (SqlConnection conn = new SqlConnection(connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "SELECT BBetaaldBedrag FROM Bestelling WHERE BBetalld = 1 AND BDatumBetaald >= @dag1 AND BDatumBetaald < @dag2;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@dag1", eerstedagvandeweek);
                            cmd.Parameters.AddWithValue("@dag2", eerstedagvandeweek.AddDays(7)); // Add 7 dagen want de 7e dag is maandag 00:00:00 AM

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    for(int i = 0; i < 6; i++)
                                    {
                                        if (!reader.IsDBNull(i))
                                        {
                                            omzet.Add(reader.GetDecimal(i));
                                        }
                                    }
                                    return omzet;
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

        public List<decimal> GetOmzetPerWeek(DateTime eerstedagvandemaand)
        {
            throw new System.NotImplementedException();
        }

        public List<decimal> GetOmzetPerMaand(DateTime jaartal)
        {
            throw new System.NotImplementedException();
        }

        public List<decimal> GetOmzetPerJaar()
        {
            throw new System.NotImplementedException();
        }
    }
}
