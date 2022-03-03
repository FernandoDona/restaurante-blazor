using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Data.EFCore.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public OrderStatusEnum Status { get; set; }
        [Required]
        public List<Product> Products { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
