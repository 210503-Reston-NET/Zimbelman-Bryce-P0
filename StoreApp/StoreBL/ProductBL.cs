using System.Collections.Generic;
using StoreModels;
using StoreDL;
using System;

namespace StoreBL
{
    /// <summary>
    /// Businss logic class for product model
    /// </summary>
    public class ProductBL : IProductBL
    {
        private IRepository _repo;
        public ProductBL(IRepository repo) {
            _repo = repo;
        }
        public Product AddProduct(Product product)
        {
            if (_repo.GetProduct(product) != null) {
                throw new Exception ("Product already exists");
            }
            return _repo.AddProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public double GetTotal(List<int> quantity)
        {
            int i = 0;
            double total = 0;
            List<Product> products = GetAllProducts();
            foreach (Product product in products) {
                total += quantity[i] * product.Price;
                i++;
            }
            return total;
        }
    }
}