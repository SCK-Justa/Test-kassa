using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IAuthenticationServices
    {
        bool CheckLogin(string gebruikersnaam, string wachtwoord);
        int GetPersoonIdFromLogin(string gebruikersnaam, string wachtwoord);
        Authentication GetAuthenticationFromId(int id);
        List<Authentication> GetAuthentications();
        void AddAuthentication(Authentication authentication);
        void EditAuthentication(Authentication authentication);
        void RemoveAuthentication(Authentication authentication);
    }
}
