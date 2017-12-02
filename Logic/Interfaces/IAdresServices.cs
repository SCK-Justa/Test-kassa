using System;
using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IAdresServices
    {
        Adres GetAdresById(int adresId);
        List<Adres> GetAdressenByCity(string city);
        List<Adres> GetAdresByPostcode(string postcode);
        Adres AddAdres(Adres adres);
        void EditAdres(Adres adres);
        void RemoveAdres(Adres adres);
    }
}
