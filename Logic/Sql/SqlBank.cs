using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Sql
{
    public class SqlBank : IBankServices
    {
        private string connectie;
        public SqlBank(string connectie)
        {
            this.connectie = connectie;
        }

        public Bank GetBankById(int id)
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
                            cmd.CommandText = "SELECT * FROM Bank WHERE BankId = @bankId;";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@bankId", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                int bankId = reader.GetInt32(0);
                                string bankNaam = reader.GetString(1);
                                string rekeningNr = reader.GetString(2);

                                Bank bank = new Bank(bankId, bankNaam.Replace(" ", ""), rekeningNr.Replace(" ", ""));
                                return bank;
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

        public List<Bank> GetBanken()
        {
            throw new NotImplementedException();
        }

        public Bank AddBank(Bank bank)
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
                            cmd.CommandText = "INSERT INTO Bank VALUES (@banknaam, @rekeningnummer);";
                            cmd.Connection = conn;

                            cmd.Parameters.AddWithValue("@banknaam", bank.Naam);
                            cmd.Parameters.AddWithValue("@rekeningnummer", bank.Rekeningnummer);

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT BankId FROM Bank ORDER BY BankId DESC;";
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    return GetBankById(id);
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

        public void EditBank(Bank bank)
        {
            throw new NotImplementedException();
        }

        public void RemoveBank(Bank bank)
        {
            throw new NotImplementedException();
        }
    }
}
