using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class OudercontactRepository
    {
        private IOuderContactServices _ouderContactServices;
        public OudercontactRepository(IOuderContactServices ouderContactServices)
        {
            _ouderContactServices = ouderContactServices;
        }
        public Oudercontact GetOudercontactById(int id)
        {
            return _ouderContactServices.GetOudercontactById(id);
        }

        public List<Oudercontact> GetOudercontacten()
        {
            return _ouderContactServices.GetOudercontacten();
        }

        public void AddOudercontact(Oudercontact contact)
        {
            _ouderContactServices.AddOudercontact(contact);
        }

        public void EditOudercontact(Oudercontact contact)
        {
            _ouderContactServices.EditOudercontact(contact);
        }

        public void RemoveOudercontact(Oudercontact contact)
        {
            _ouderContactServices.RemoveOudercontact(contact);
        }
    }
}
