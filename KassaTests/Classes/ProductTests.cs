using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Classes.Tests
{
    [TestClass()]
    public class ProductTests
    {
        Product product;
        Product testProduct;

        [TestInitialize()] 
        public void TestInitialize()
        {
            testProduct = new Product(0, "Chocomel", "Frisdrank", 48, 1.40m, 1.75m);
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
    }
}