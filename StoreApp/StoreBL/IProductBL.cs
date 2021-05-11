using System.Collections.Generic;
using StoreModels;

namespace StoreBL
{
    public interface IProductBL
    {
        Product AddProduct(Product product);
        List<Product> GetAllProducts();
    }
}