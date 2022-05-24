using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Imagebase64 { get; set; }
    }
}
