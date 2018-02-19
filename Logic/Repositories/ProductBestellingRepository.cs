using System;
using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class ProductBestellingRepository
    {
        private IProductenBestellingServices _productenBestellingServices;
        public ProductBestellingRepository(IProductenBestellingServices productenBestellingServices)
        {
            _productenBestellingServices = productenBestellingServices;
        }
        public void AddProductToBestelling(Bestelling bestelling, Product product)
        {
            _productenBestellingServices.AddProductToBestelling(bestelling, product);
        }

        public LosseVerkoop AddLosseVerkoop(LosseVerkoop verkoop)
        {
            return _productenBestellingServices.AddLosseVerkoop(verkoop);
        }

        public void EditProductInBestelling(Bestelling bestelling, Product product)
        {
            _productenBestellingServices.EditProductInBestelling(bestelling, product);
        }

        public void RemoveProductFromBestelling(Bestelling bestelling, Product product)
        {
            _productenBestellingServices.RemoveProductFromBestelling(bestelling, product);
        }

        public List<LosseVerkoop> GetLosseVerkopen(DateTime beginDate, DateTime endDate)
        {
            return _productenBestellingServices.GetLosseVerkopen(beginDate, endDate);
        }

        public void RemoveProductFromLosseVerkoop(LosseVerkoop verkoop)
        {
            _productenBestellingServices.RemoveProductFromLosseVerkoop(verkoop);
        }
    }
}
