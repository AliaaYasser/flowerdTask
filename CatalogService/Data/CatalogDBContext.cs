using CatalogService.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CatalogService.Data
{
    public class CatalogDBContext: DbContext
    {
       
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options) { }
       
        public DbSet<Product> Products { get; set; }
        
    }
}
