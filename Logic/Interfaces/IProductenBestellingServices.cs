using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IProductenBestellingServices
    {
        void AddProductToBestelling(Bestelling bestelling, Product product);
        void AddLosseVerkoop(Product product);
        void EditProductInBestelling(Bestelling bestelling, Product product);
        void RemoveProductFromBestelling(Bestelling bestelling, Product product);
    }
}
