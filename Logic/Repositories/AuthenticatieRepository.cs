using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    class AuthenticatieRepository
    {
        private IAuthenticationServices _authenticationServices;
        public AuthenticatieRepository(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }
        public bool CheckLogin(string gebruikersnaam, string wachtwoord)
        {
           return _authenticationServices.CheckLogin(gebruikersnaam, wachtwoord);
        }

        public int GetPersoonIdFromLogin(string gebruikersnaam, string wachtwoord)
        {
            return _authenticationServices.GetPersoonIdFromLogin(gebruikersnaam, wachtwoord);
        }

        public Authentication GetAuthenticationFromId(int id)
        {
            return _authenticationServices.GetAuthenticationFromId(id);
        }

        public List<Authentication> GetAuthentications()
        {
           return _authenticationServices.GetAuthentications();
        }

        public void AddAuthentication(Authentication authentication)
        {
            _authenticationServices.AddAuthentication(authentication);
        }

        public void EditAuthentication(Authentication authentication)
        {
            _authenticationServices.EditAuthentication(authentication);
        }

        public void RemoveAuthentication(Authentication authentication)
        {
            _authenticationServices.RemoveAuthentication(authentication);
        }
    }
}
