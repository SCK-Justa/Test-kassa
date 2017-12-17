using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class ProductRepository
    {
        private IProductServices _productServices;

        public ProductRepository(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public Product GetProductByName(string name)
        {
            return _productServices.GetProductByName(name);
        }

        public Product GetProductById(int id)
        {
            return _productServices.GetProductById(id);
        }

        public List<Product> GetProducten()
        {
            return _productServices.GetProducten();
        }

        public void AddProduct(Product product)
        {
            _productServices.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            _productServices.EditProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            _productServices.RemoveProduct(product);
        }
    }
}
