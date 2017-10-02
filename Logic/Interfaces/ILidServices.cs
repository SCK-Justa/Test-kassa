using System;
using Logic.Classes;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface ILidServices
    {
        Lid GetLidFromId(int lidId);
        Lid GetPersoonFromBondsnummer(int bondsnummer);
        Lid GetPersoonFromFullName(string firstname, string lastname);
        List<Lid> GetAllLeden();
        List<Lid> GetPersonenFromDateOfBirth(DateTime dateOfBirth);
        List<Lid> GetPersonenFromLidVanaf(DateTime dateVanaf);
        void AddPersoon(Lid lid);
        void EditPersoon(Lid lid);
        void RemovePersoon(Lid lid);
    }
}
