using System;
using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IProductenBestellingServices
    {
        void AddProductToBestelling(Bestelling bestelling, Product product);
        LosseVerkoop AddLosseVerkoop(LosseVerkoop verkoop);
        void EditProductInBestelling(Bestelling bestelling, Product product);
        void RemoveProductFromBestelling(Bestelling bestelling, Product product);
        List<LosseVerkoop> GetLosseVerkopen(DateTime beginDate, DateTime endDate);
        void RemoveProductFromLosseVerkoop(LosseVerkoop verkoop);
    }
}
