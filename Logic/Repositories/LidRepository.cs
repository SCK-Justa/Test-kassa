using System;
using System.Collections.Generic;
using Logic.Interfaces;
using Logic.Classes;


namespace Logic.Repositories
{
    public class LidRepository
    {
        private ILidServices _lidServices;

        public LidRepository(ILidServices lidServices)
        {
            _lidServices = lidServices;
        }

        public Lid GetPersoonFromId(int lidId)
        {
            return _lidServices.GetLidFromId(lidId);
        }

        public Lid GetPersoonFromBondsnummer(int bondsnummer)
        {
           return _lidServices.GetPersoonFromBondsnummer(bondsnummer);
        }

        public Lid GetPersoonFromFullName(string firstname, string lastname)
        {
            return _lidServices.GetPersoonFromFullName(firstname, lastname);
        }

        public List<Lid> GetAllLeden()
        {
            return _lidServices.GetAllLeden();
        }

        public List<Lid> GetPersonenFromDateOfBirth(DateTime dateOfBirth)
        {
            return _lidServices.GetPersonenFromDateOfBirth(dateOfBirth);
        }

        public List<Lid> GetPersonenFromLidVanaf()
        {
            return _lidServices.GetPersonenFromLidVanaf();
        }

        public void AddPersoon(Lid lid)
        {
            _lidServices.AddPersoon(lid);
        }

        public void EditPersoon(Lid lid)
        {
            _lidServices.EditPersoon(lid);
        }

        public void DeletePersoon(Lid lid)
        {
            _lidServices.RemovePersoon(lid);
        }
    }
}
