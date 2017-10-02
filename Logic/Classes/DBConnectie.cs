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
    }
}
