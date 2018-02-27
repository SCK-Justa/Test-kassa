using Logic.Repositories;
using Logic.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Logic.Classes
{
    public class Database
    {
        private string _connectieString;
        private bool IsConnected;

        public BestellingRepository BestellingRepo { get; private set; }
        public LidRepository LedenRepo { get; private set; }
        public AdresRepository AdresRepo { get; private set; }
        public BankRepository BankRepo { get; private set; }
        public OudercontactRepository OudercontactRepo { get; private set; }
        public AuthenticatieRepository AuthenticatieRepo { get; private set; }
        public ProductBestellingRepository ProductbestellingRepo { get; private set; }
        public ProductRepository ProductRepo { get; private set; }
        public KassaRepository KassaRepo { get; private set; }
        public OmzetRepository OmzetRepo { get; private set; }
        public LedenLogRepository LedenlogRepo { get; private set; }
        public KlasseRepository KlasseRepo { get; private set; }
        public KassaLogRepository KassaLogRepo { get; private set; }

        public Database()
        {
            //WriteFile();
            IsConnected = false;
            _connectieString = GetConnectionString("Authentication.txt");
            TryDatabaseConnection();
            if (IsConnected)
            {
                GetDatabaseStuff();
            }
        }

        public bool TryDatabaseConnection()
        {
            try
            {
                if (_connectieString == "")
                {
                    return false;
                }
                using (SqlConnection conn = new SqlConnection(_connectieString))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                        IsConnected = true;
                        return IsConnected;
                    }
                }
                IsConnected = false;
                return IsConnected;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public string GetConnectieString()
        {
            return _connectieString;
        }

        public bool GetIsConnected()
        {
            return IsConnected;
        }

        private string GetConnectionString(string file)
        {
            try
            {
                string ip;
                string database;
                string username;
                string password;
                using (StreamReader reader = new StreamReader(file))
                {
                    ip = reader.ReadLine();
                    database = reader.ReadLine();
                    username = reader.ReadLine();
                    password = reader.ReadLine();
                }
                string connstring =
                    $@"Server={ip};Database={database};User ID={username};Password={password};";
                return connstring;
            }
            catch (IOException iox)
            {
                throw new Exception(iox.Message);
            }
        }


        private void GetDatabaseStuff()
        {
            LedenlogRepo = new LedenLogRepository(new SqlLedenLog(_connectieString));
            BestellingRepo = new BestellingRepository(new SqlBestelling(_connectieString));
            LedenRepo = new LidRepository(new SqlLid(_connectieString));
            AdresRepo = new AdresRepository(new SqlAdres(_connectieString));
            BankRepo = new BankRepository(new SqlBank(_connectieString));
            OudercontactRepo = new OudercontactRepository(new SqlOudercontact(_connectieString));
            AuthenticatieRepo = new AuthenticatieRepository(new SqlAuthentication(_connectieString));
            ProductbestellingRepo = new ProductBestellingRepository(new SqlProductBestelling(_connectieString));
            ProductRepo = new ProductRepository(new SqlProduct(_connectieString));
            KassaRepo = new KassaRepository(new SqlKassa(_connectieString));
            OmzetRepo = new OmzetRepository(new SqlOmzet(_connectieString));
            KlasseRepo = new KlasseRepository(new SqlKlasse(_connectieString));
            KassaLogRepo = new KassaLogRepository(new SqlKassaLog(_connectieString));
        }
    }
}
