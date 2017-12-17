using System;
using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IBestellingServices
    {
        Bestelling GetBestellingById(int bestellingId);
        List<Bestelling> GetBestellingenVanLid(Lid lid);
        List<Bestelling> GetAllBestellingen();
        List<Bestelling> GetBestellingenBetweenDates(DateTime beginDate, DateTime endDate);
        List<Bestelling> GetUnpaidBestellingen();
        List<Product> GetProductenInBestelling(int bestellingId);
        int AddBestellingMetPersoon(Bestelling bestelling);
        int AddBestellingMetNaam(Bestelling bestelling);
        void EditBestelling(Bestelling bestelling);
        void DeleteBestelling(Bestelling bestelling);
        void BetaalBestelling(Bestelling bestelling);
    }
}
