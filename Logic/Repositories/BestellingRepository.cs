using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class BestellingRepository
    {
        private IBestellingServices _bestellingServices;
        public BestellingRepository(IBestellingServices bestellingeServices)
        {
            _bestellingServices = bestellingeServices;
        }

        public Bestelling GetBestellingById(int bestellingId)
        {
            return _bestellingServices.GetBestellingById(bestellingId);
        }

        public List<Bestelling> GetBestellingenVanLid(Lid lid)
        {
            return _bestellingServices.GetBestellingenVanLid(lid);
        }

        public List<Bestelling> GetAllBestellingen()
        {
            return _bestellingServices.GetAllBestellingen();
        }

        public List<Product> GetProductenInBestelling(int bestellingId)
        {
            return _bestellingServices.GetProductenInBestelling(bestellingId);
        }

        public int AddBestellingMetPersoon(Bestelling bestelling)
        {
            return _bestellingServices.AddBestellingMetPersoon(bestelling);
        }

        public int AddBestellingMetNaam(Bestelling bestelling)
        {
            return _bestellingServices.AddBestellingMetNaam(bestelling);
        }


        public void EditBestelling(Bestelling bestelling)
        {
            _bestellingServices.EditBestelling(bestelling);
        }

        public void DeleteBestelling(Bestelling bestelling)
        {
            _bestellingServices.DeleteBestelling(bestelling);
        }

        public void BetaalBestelling(Bestelling bestelling)
        {
            _bestellingServices.BetaalBestelling(bestelling);
        }
    }
}
