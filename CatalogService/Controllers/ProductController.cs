using CatalogService.Interfaces;
using CatalogService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;
        
        [HttpGet(nameof(GetAllProducts))]
        public ActionResult GetAllProducts()=>
             Ok(productService.GetAllProducts()?? new List<Product>());


        [HttpPost(nameof(CreateProduct))]
        public ActionResult CreateProduct(Product product)
        {
            var createdProduct= productService.CreateProduct(product);
            if (createdProduct!=null)
                return Ok(createdProduct);

            return BadRequest();
        }


        [HttpGet(nameof(GetProduct))]
        public ActionResult GetProduct( int productID)
        {
            var product= productService.GetProduct(productID);
            if (product != null)
                return Ok(product);
            return NotFound($"product with id={productID} is not found");
        }

        [HttpPost(nameof(EditProduct))]
        public ActionResult EditProduct(int id,Product product)
        {
            var UpdatedProduct= productService.UpdateProduct(id, product);
            if(UpdatedProduct!=null)
                return Ok(UpdatedProduct);

            return BadRequest($"Something Went wrong  while update product with ProductId={id}");
        }

       
       [HttpGet(nameof(DeleteProduct))]
        public ActionResult DeleteProduct(int id)
        {
            var DeletedProduct = productService.DeleteProduct(id);
            if (DeletedProduct!=null )
                return Ok(DeletedProduct);
            return BadRequest($"Something Went wrong  while update product with ProductId={id}");
        }

       
    }
}
