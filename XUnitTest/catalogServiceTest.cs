using CatalogService.Controllers;
using CatalogService.Interfaces;
using CatalogService.RepositiryServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace XUnitTest
{
    public class catalogServiceTest
    {
        private readonly IProductService productService;
        public catalogServiceTest()
        {
            var dbOption = new DbContextOptionsBuilder<CatalogService.Data.CatalogDBContext>()
    .UseSqlServer("Server=.;Database=Catalog;Trusted_Connection=True;Integrated Security=True;")
    .Options;
            productService = new ProductService(new ProductRepository(new CatalogService.Data.CatalogDBContext(dbOption)), new MessageProducer());
        }
        #region Get By Id  

        [Fact]
        public  void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new ProductController(productService);
            var id = 2;

            //Act  
            var data =  controller.GetProduct(id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public  void Task_GetPostById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ProductController(productService);
            var id = 3;

            //Act  
            var data =  controller.GetProduct(id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public  void Task_GetPostById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ProductController(productService);
            int? id = null;

            //Act  
            var data =  controller.GetProduct(id.Value);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }


        #endregion
    }
}