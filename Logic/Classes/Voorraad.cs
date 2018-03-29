using System;
using System.Collections.Generic;
using Logic.Classes.Enums;

namespace Logic.Classes
{
    public class Voorraad // Berging
    {
        public List<Product> ProductenInVoorraad { get; private set; }

        public Voorraad(bool dbconnectie)
        {
            ProductenInVoorraad = new List<Product>();
            if (!dbconnectie)
            {
                AddProductList();
            }
        }

        public void AddProduct(Product product)
        {
            ProductenInVoorraad.Add(product);
        }

        public void AddProductenFromDb(List<Product> producten)
        {
            ProductenInVoorraad = producten;
        }

        public VoorraadControle ChangeProduct(Product _product, Lid controleur, int oudeVoorraad, int nieuweVoorraad)
        {
            VoorraadControle controle = null;
            foreach (Product product in ProductenInVoorraad)
            {
                if (product.Id == _product.Id)
                {
                    controle = new VoorraadControle(product, controleur, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                        oudeVoorraad, nieuweVoorraad, VoorraadEnum.Telling);
                    product.AddVoorraadControle(controle);
                }
            }
            return controle;
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
            foreach (Product p in ProductenInVoorraad)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        public VoorraadControle VoegVoorraadToe(Product product, int hoeveelheid, Lid controleur)
        {
            int oudeVoorraad, nieuweVoorraad;
            oudeVoorraad = product.Voorraad;
            product.SetVoorraad(hoeveelheid);
            nieuweVoorraad = product.Voorraad;
            VoorraadControle controle = new VoorraadControle(product, controleur, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                oudeVoorraad, nieuweVoorraad, VoorraadEnum.Levering);
            product.AddVoorraadControle(controle);
            return controle;
        }

        public void AddProductList()
        {
            ProductenInVoorraad.Add(new Product(0, "Koffie", "Koffie", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(1, "Thee", "Koffie", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(2, "Coca Cola", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(3, "Coca Cola Zero", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(4, "Fanta", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(5, "Fanta Cassis", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(6, "Spa Rood", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(7, "Chocomel", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(8, "Aquarius", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(9, "AA-Drink", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(10, "Ice Tea", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(11, "Bitter Lemon", "Frisdrank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(12, "Hertog-Jan", "Bier", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(13, "Jupiler Alcoholvrij", "Bier", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(14, "Barbar Blond", "Bier", 100, 2.10m, 2.75m));
            ProductenInVoorraad.Add(new Product(15, "Leffe Bruin", "Bier", 100, 2.10m, 2.75m));
            ProductenInVoorraad.Add(new Product(16, "Schrobbeler", "Sterke drank", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(17, "Naturel Chips", "Eten", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(18, "Paprika Chips", "Eten", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(19, "Snickers", "Eten", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(20, "Mars", "Eten", 100, 0.70m, 1.25m));
            ProductenInVoorraad.Add(new Product(21, "BiFi", "Eten", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(22, "Frikandel", "Eten", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(23, "Bitterballen", "Eten", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(24, "Broodje Frikandel", "Broodjes", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(25, "Hotdog", "Broodjes", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(26, "Broodje Kaas", "Broodjes", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(27, "Broodje Ham", "Broodjes", 100, 1.40m, 1.75m));
            ProductenInVoorraad.Add(new Product(28, "Munten", "Accesoires", 100, 7.00m, 7.00m));
            ProductenInVoorraad.Add(new Product(29, "Sint Sebastiaan Pen", "Accesoires", 100, 2.50m, 2.50m));
        }
    }
}