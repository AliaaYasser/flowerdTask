using CatalogService.Data;
using CatalogService.Interfaces;
using CatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogService.RepositiryServices
{
    public class ProductRepository : IProductReposetiory
    {
        private readonly CatalogDBContext dBContext;

        public ProductRepository(CatalogDBContext dBContext)=>this.dBContext = dBContext;
        
        public Product CreateProduct(Product product)
        {
            product.Id = default;
            dBContext.Add(product);
            dBContext.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int productId)
        {
            var productToBeDeleted= dBContext.Products.SingleOrDefault(item=>item.Id==productId);
            if (productToBeDeleted != null)
            {
                dBContext.Remove(productToBeDeleted);
                dBContext.SaveChanges();
                return productToBeDeleted;
            }
            else
                return null;
        }

        public List<Product> GetAllProducts()=> dBContext.Products.ToList();

        public Product GetProduct(int productId) => dBContext.Products.FirstOrDefault(i=>i.Id==productId);

        public Product UpdateProduct(int productId, Product product)
        {
            if (productId != product.Id)
                return null;

            dBContext.Update(product);
            dBContext.SaveChanges();
            return product;
        }
    }
}
