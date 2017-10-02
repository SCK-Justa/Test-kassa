﻿using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IBestellingServices
    {
        Bestelling GetBestellingById(int bestellingId);
        List<Bestelling> GetBestellingenVanLid(Lid lid);
        List<Bestelling> GetAllBestellingen();
        List<Product> GetProductenInBestelling(int bestellingId);
        void AddBestellingMetPersoon(Bestelling bestelling);
        void AddBestellingMetNaam(Bestelling bestelling);
        void EditBestelling(Bestelling bestelling);
        void DeleteBestelling(Bestelling bestelling);
        void BetaalBestelling(Bestelling bestelling);
    }
}
