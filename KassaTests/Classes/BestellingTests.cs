using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Classes;
using System;

namespace UTestsKassa.Classes
{
    [TestClass()]
    public class BestellingBestellingTests
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            Klasse klasse = new Klasse(0, "Aspirant", 6, 12);
            Adres adres = new Adres(0, "Abcd", "1", "1234 AB", "Amsterdam");
            Lid lid = new Lid(DateTime.Now, klasse, klasse, 0, 161378, "Jelle", "", "Schrader", "testemail@test.nl", "H", DateTime.Now, adres, "0131234567", "0612345678");
            Bestelling testBestelling = new Bestelling(0, lid, DateTime.Now);
        }

        [TestMethod()]
        public void BestellingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BestellingTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BestellingTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BestellingTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BestellingTest4()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BestellingTest5()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetPersoonTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNaamTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDatumTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDatumBetaaldTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetBetaaldBedragTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetKassaIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetBetaaldTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTotaalPrijsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTotaalLedenPrijsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetBetaaldMetBonnenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddProductenToListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetProductenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BerekenTotaalPrijsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddProductToListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveProductFromListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfrekenenTest()
        {
            Assert.Fail();
        }
    }
}