using System.Collections.Generic;

namespace Logic.Classes
{
    public class Voorraad // Berging
    {
        private Product product;
        public List<Product> ProductenInVoorraad { get; private set; }

        public Voorraad()
        {
            ProductenInVoorraad = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            ProductenInVoorraad.Add(product);
        }

        public void AddProductenFromDb(List<Product> producten)
        {
            ProductenInVoorraad = producten;
        }

        public void ChangeProduct(int oId, Product _product)
        {
            foreach (Product product in ProductenInVoorraad)
            {
                if (product.Id == oId)
                {
                    product.SetNaam(_product.Naam);
                    product.SetSoort(_product.Soort);
                    product.SetPrijs(_product.Prijs);
                    product.SetLedenprijs(_product.Ledenprijs);
                    product.SetVoorraad(_product.Voorraad);
                }
            }
        }

        public List<Product> GetProducten()
        {
            if (ProductenInVoorraad == null)
            {
                return new List<Product>();
            }
            return ProductenInVoorraad;
        }

        public Product VindProductOpNaam(string productnaam)
        {
            foreach (Product p in ProductenInVoorraad)
            {
                if (p.Naam == productnaam)
                {
                    return p;
                }
            }
            return null;
        }

        public Product VindProductOpId(int id)
        {
            foreach(Product p in ProductenInVoorraad)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public void PasVoorraadAan(int hoeveelheid, string productnaam)
        {
            product = VindProductOpNaam(productnaam);
            product.SetVoorraad(product.Voorraad - hoeveelheid);
        }
    }
}