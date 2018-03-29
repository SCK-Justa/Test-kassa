using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Classes;
using System;
using System.Collections.Generic;

namespace UTestsKassa.Classes
{
    [TestClass()]
    public class BestellingBestellingTests
    {
        Klasse klasse;
        Adres adres;
        Lid lid;
        Bestelling testBestelling;
        Bestelling bestelling;
        List<Product> producten;
        Product product;
        Product product2;

        [TestInitialize()]
        public void TestInitialize()
        {
            producten = new List<Product>();
            product = new Product(0, "Cola", "Frisdrank", 48, 1.40m, 1.75m);
            product2 = new Product(1, "Chocomel", "Frisdrank", 48, 1.40m, 1.75m);
            producten.Add(product);
            producten.Add(product2);
            klasse = new Klasse(0, "Aspirant", 6, 12);
            adres = new Adres(0, "Abcd", "1", "1234 AB", "Amsterdam");
            lid = new Lid(DateTime.Now, klasse, klasse, 0, 161378, "Jelle", "", "Schrader", "testemail@test.nl", "H", DateTime.Now, adres, "0131234567", "0612345678");
            testBestelling = new Bestelling(0, lid, DateTime.Now);
        }

        [TestMethod()]
        public void BestellingTest()
        {
            bestelling = new Bestelling(DateTime.Now);

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void BestellingTest1()
        {
            bestelling = new Bestelling(lid, DateTime.Now);

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void BestellingTest2()
        {
            bestelling = new Bestelling("Testpersoon", DateTime.Now);

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void BestellingTest3()
        {
            bestelling = new Bestelling(0, lid, DateTime.Now);

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void BestellingTest4()
        {
            DateTime now = DateTime.Now;
            now = DateTime.Now.AddDays(5);
            bestelling = new Bestelling(0, "Testpersoon", DateTime.Now);

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void BestellingTest5()
        {
            DateTime now = DateTime.Now;
            now = DateTime.Now.AddDays(5);
            bestelling = new Bestelling(0, "Testpersoon", DateTime.Now.ToString(), now.ToString());

            Assert.AreNotEqual(bestelling, null);
        }

        [TestMethod()]
        public void SetPersoonTest()
        {
            lid = new Lid(DateTime.Now, 0, "Testpersoon", "", "Testachternaam", "Email", "H", DateTime.Now, null, "0123456789", "0612345678");
            testBestelling.SetPersoon(lid);

            Assert.AreEqual(testBestelling.Lid, lid);
            Assert.AreEqual(testBestelling.Lid.Voornaam, "Testpersoon"); // Voor het visuele, dat het lid ECHT is aangepast.
        }

        [TestMethod()]
        public void SetNaamTest()
        {
            string nieuweNaam = "Nieuwe naam";
            testBestelling.SetNaam(nieuweNaam);

            Assert.AreEqual(testBestelling.Naam, nieuweNaam);
        }

        [TestMethod()]
        public void SetDatumTest()
        {
            DateTime nieuweDateTime = DateTime.Now.AddDays(7);
            testBestelling.SetDatum(nieuweDateTime);

            Assert.AreEqual(testBestelling.Datum, nieuweDateTime);
        }

        [TestMethod()]
        public void SetDatumBetaaldTest()
        {
            DateTime nieuweDateTime = DateTime.Now.AddDays(7);
            testBestelling.SetDatumBetaald(nieuweDateTime);

            Assert.AreEqual(testBestelling.DatumBetaald, nieuweDateTime);
        }

        [TestMethod()]
        public void SetBetaaldBedragTest()
        {
            decimal bedrag = 10.00m;
            testBestelling.SetBetaaldBedrag(bedrag);

            Assert.AreEqual(testBestelling.BetaaldBedrag, bedrag);
        }

        [TestMethod()]
        public void SetKassaIdTest()
        {
            int kassaId = 10;
            testBestelling.SetKassaId(kassaId);

            Assert.AreEqual(testBestelling.KassaId, kassaId);
        }

        [TestMethod()]
        public void SetBetaaldTest()
        {
            bool betaald = true;
            testBestelling.SetBetaald(betaald);

            Assert.AreEqual(testBestelling.Betaald, betaald);
        }

        [TestMethod()]
        public void SetTotaalPrijsTest()
        {
            decimal totaalPrijs = 14.00m;
            testBestelling.SetTotaalPrijs(totaalPrijs);

            Assert.AreEqual(testBestelling.TotaalPrijs, totaalPrijs);
        }

        [TestMethod()]
        public void SetTotaalLedenPrijsTest()
        {
            decimal totaalPrijs = 14.00m;
            testBestelling.SetTotaalLedenPrijs(totaalPrijs);

            Assert.AreEqual(testBestelling.TotaalLedenPrijs, totaalPrijs);
        }

        [TestMethod()]
        public void SetBetaaldMetBonnenTest()
        {
            bool betaald = true;
            testBestelling.SetBetaaldMetMunten(betaald);

            Assert.AreEqual(testBestelling.BetaaldMetMunten, betaald);
        }

        [TestMethod()]
        public void AddProductenToListTest()
        {
            testBestelling.AddProductenToList(producten); // Lijst van 2 producten toevoegen

            Assert.AreEqual(testBestelling.GetProducten().Count, 2);

            producten.Add(new Product(2, "Fanta", "Frisdrank", 48, 1.40m, 1.75m));
            testBestelling.AddProductenToList(null); // Eerst op null zetten zodat de lijst leeg is

            Assert.AreEqual(testBestelling.GetProducten(), null);

            testBestelling.AddProductenToList(producten); // Dan de lijst met 3 producten toevoegen

            Assert.AreEqual(testBestelling.GetProducten().Count, 3);

            testBestelling.AddProductenToList(null); // Terug op null voor de volgende test
        }

        [TestMethod()]
        public void GetProductenTest()
        {
            testBestelling.AddProductenToList(producten);
            Assert.AreEqual(testBestelling.GetProducten().Count, 2);
        }

        [TestMethod()]
        public void BerekenTotaalPrijsTest()
        {
            decimal totaalPrijs = 0;
            testBestelling.AddProductenToList(producten);
            for (int i = 0; i < producten.Count; i++)
            {
                totaalPrijs += producten[i].Prijs;
            }

            Assert.AreEqual(testBestelling.TotaalPrijs, totaalPrijs);
        }

        [TestMethod()]
        public void AddProductToListTest()
        {
            testBestelling.AddProductenToList(producten);
            testBestelling.AddProductToList(new Product(2, "Fanta", "Frisdrank", 48, 1.40m, 1.75m));

            Assert.AreEqual(testBestelling.GetProducten().Count, 3);
        }

        [TestMethod()]
        public void RemoveProductFromListTest()
        {
            testBestelling.AddProductenToList(producten);
            testBestelling.RemoveProductFromList(product);

            Assert.AreEqual(testBestelling.GetProducten().Count, 1);
        }

        [TestMethod()]
        public void AfrekenenTest()
        {
            testBestelling.Afrekenen(3.50m, DateTime.Now, true);

            Assert.AreEqual(testBestelling.Betaald, true);
        }

        [TestMethod()]
        public void NoNameAndLidAtTheSameTimeTest()
        {
            testBestelling.SetNaam("Testnaam");

            Assert.AreEqual(testBestelling.Lid, null);

            testBestelling.SetPersoon(lid);

            Assert.AreEqual(testBestelling.Naam, "");
        }
    }
}