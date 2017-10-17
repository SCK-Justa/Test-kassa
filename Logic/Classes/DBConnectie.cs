using System;
using System.Data;
using System.Data.SqlClient;

namespace Logic.Classes
{
    public class DBConnectie
    {
        private string Connectie;

        public DBConnectie(string connectie)
        {
            Connectie = connectie;
        }

        public string GetConnectieString()
        {
            return Connectie;
        }

        public bool TryConnection()
        {
            try
            {
                if (Connectie == "")
                {
                    return false;
                }
                using (SqlConnection conn = new SqlConnection(Connectie))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
