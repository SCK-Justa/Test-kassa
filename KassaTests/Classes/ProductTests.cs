using System;
using System.Collections.Generic;
using Logic.Classes.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Classes.Tests
{
    [TestClass()]
    public class ProductTests
    {
        private Product product;
        private Product testProduct;
        private Lid testLid;
        private Klasse klasse;
        private Adres adres;
        private VoorraadControle controle;
        private List<VoorraadControle> controles;

        [TestInitialize()] 
        public void TestInitialize()
        {
            testProduct = new Product(0, "Chocomel", "Frisdrank", 48, 1.40m, 1.75m);
            klasse = new Klasse(0, "Aspirant", 6, 12);
            adres = new Adres(0, "Abcd", "1", "1234 AB", "Amsterdam");
            testLid = new Lid(DateTime.Now, klasse, klasse, 0, 161378, "Jelle", "", "Schrader", "testemail@test.nl", "H", DateTime.Now, adres, "0131234567", "0612345678");
            controles = new List<VoorraadControle>();
        }

        [TestMethod()]
        public void ProductTest()
        {
            product = new Product("Coca cola", "Frisdrank", 48, 1.40m, 1.75m);

            Assert.AreNotEqual(product, null);
        }

        [TestMethod()]
        public void ProductTest1()
        {
            product = new Product(1, "Coca cola", "Frisdrank", 48, 1.40m, 1.75m);

            Assert.AreNotEqual(product, null);
        }

        [TestMethod()]
        public void SetNaamTest()
        {
            string nieuweNaam = "Fristy";
            testProduct.SetNaam(nieuweNaam);

            Assert.AreEqual(testProduct.Naam, nieuweNaam);
        }

        [TestMethod()]
        public void SetSoortTest()
        {
            string nieuweSoort = "Melkproduct";
            testProduct.SetSoort(nieuweSoort);

            Assert.AreEqual(testProduct.Soort, nieuweSoort);
        }

        [TestMethod()]
        public void SetVoorraadTest()
        {
            int nieuweVoorraad = 72;
            testProduct.SetVoorraad(nieuweVoorraad);

            Assert.AreEqual(testProduct.Voorraad, nieuweVoorraad);
        }

        [TestMethod()]
        public void SetLedenprijsTest()
        {
            decimal nieuweLedenprijs = 1.60m;
            testProduct.SetLedenprijs(nieuweLedenprijs);

            Assert.AreEqual(testProduct.Ledenprijs, nieuweLedenprijs);
        }

        [TestMethod()]
        public void SetPrijsTest()
        {
            decimal nieuwePrijs = 1.60m;
            testProduct.SetPrijs(nieuwePrijs);

            Assert.AreEqual(testProduct.Prijs, nieuwePrijs);
        }

        [TestMethod()]
        public void AddVoorraadControleTest()
        {
            testProduct.AddVoorraadControle(controle);

            Assert.AreEqual(testProduct.GetVoorraadOpbouw().Count, 1);
        }

        [TestMethod()]
        public void GetVoorraadControleTest()
        {
            testProduct.AddVoorraadControle(controle);
            testProduct.AddVoorraadControle(controle);

            Assert.AreEqual(testProduct.GetVoorraadOpbouw().Count, 2);
        }

        [TestMethod()]
        public void AddVoorraadOpbouwTest()
        {
            controle = new VoorraadControle(testProduct, testLid, DateTime.Now, 1, 5, VoorraadEnum.Levering);
            controles.Add(controle);
            testProduct.AddVoorraadOpbouw(controles);

            Assert.AreEqual(testProduct.GetVoorraadOpbouw().Count, 1);
        }
    }
}