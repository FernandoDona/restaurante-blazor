using System.ComponentModel.DataAnnotations;

namespace Restaurante.Data.EFCore.Models
{
    public class ShoppingCart
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public Order Order { get; set; }
    }
}