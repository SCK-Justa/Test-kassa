using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IProductServices
    {
        Product GetProductByName(string naam);
        Product GetProductById(int id);
        List<Product> GetProducten();
        void AddProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(Product product);
    }
}
