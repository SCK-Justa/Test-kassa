using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IOuderContactServices
    {
        Oudercontact GetOudercontactById(int id);
        List<Oudercontact> GetOudercontacten();
        void AddOudercontact(Oudercontact contact);
        void EditOudercontact(Oudercontact contact);
        void RemoveOudercontact(Oudercontact contact);
    }
}
