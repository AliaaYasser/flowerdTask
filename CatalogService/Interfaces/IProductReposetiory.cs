using CatalogService.Models;
using System.Collections.Generic;

namespace CatalogService.Interfaces
{
    public interface IProductReposetiory
    {
        public List<Product> GetAllProducts();
        public Product CreateProduct(Product product);
        public Product DeleteProduct(int productId);
        public Product UpdateProduct(int productId , Product product);
        public Product GetProduct(int productId);
    }
}
