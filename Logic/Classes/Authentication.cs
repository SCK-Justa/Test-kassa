using System.Collections.Generic;

namespace Logic.Classes
{
    public class Authentication
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string FullName { get; private set; }
        public AuthenticationSoort AuthenticationSoort { get; private set; }
        public bool Gemachtigd { get; private set; }
        public int KassaId { get; private set; }
        public Authentication(string username, string password, string fullname, bool gemachtigd)
        {
            Username = username;
            Password = password;
            FullName = fullname;
            Gemachtigd = gemachtigd;
        }

        public Authentication(int id, string username, string password, string fullname, bool gemachtigd, int kassaId) : this(username, password, fullname, gemachtigd)
        {
            Id = id;
            KassaId = kassaId;
        }

        public bool SetUsername(string username)
        {
            Username = username;
            return true;
        }

        public bool SetPassword(string password)
        {
            if (Password != password)
            {
                Password = password;
                return true;
            }
            return false;
        }

        public void SetFullName(string name)
        {
            FullName = name;
        }

        public void SetGemachtigd(bool gemachtigd)
        {
            Gemachtigd = gemachtigd;
        }
    }
}
