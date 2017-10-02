using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class AdresRepository
    {
        private IAdresServices _adresServices;
        public AdresRepository(IAdresServices adresServices)
        {
            _adresServices = adresServices;
        }

        public Adres GetAdresById(int adresId)
        {
            return _adresServices.GetAdresById(adresId);
        }

        public List<Adres> GetAdressenByCity(string city)
        {
            return _adresServices.GetAdressenByCity(city);
        }

        public List<Adres> GetAdresByPostcode(string postcode)
        {
            return _adresServices.GetAdresByPostcode(postcode);
        }

        public void AddAdres(Adres adres)
        {
            _adresServices.AddAdres(adres);
        }

        public void EditAdres(Adres adres)
        {
            _adresServices.EditAdres(adres);
        }

        public void RemoveAdres(Adres adres)
        {
            _adresServices.RemoveAdres(adres);
        }
    }
}
