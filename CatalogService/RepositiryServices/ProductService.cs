using CatalogService.Data;
using CatalogService.Interfaces;
using CatalogService.Models;
using System.Collections.Generic;
using System.Linq;


namespace CatalogService.RepositiryServices
{
    public class ProductService : IProductService
    {
        private readonly IProductReposetiory productReposetiory;
        private readonly IMessageProducer messagePublisher;

        public ProductService(IProductReposetiory productReposetiory, IMessageProducer messagePublisher)
        {
            this.productReposetiory = productReposetiory;
            this.messagePublisher=messagePublisher;
        }

        public Product CreateProduct(Product product)
        {
            productReposetiory.CreateProduct(product);
            messagePublisher.SendMessage(product);
            return product;
        }

        public Product DeleteProduct(int productId)
        {
          return  productReposetiory.DeleteProduct(productId);
        }

        public List<Product> GetAllProducts() => productReposetiory.GetAllProducts();

        public Product GetProduct(int productId) => productReposetiory.GetProduct(productId);

        public Product UpdateProduct(int productId, Product product)
        {
          return productReposetiory.UpdateProduct(productId, product);
        }
    }
}
