using System.ComponentModel.DataAnnotations;

namespace Restaurante.Data.EFCore.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string? Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}