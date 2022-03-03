using System.ComponentModel.DataAnnotations;

namespace Restaurante.Data.EFCore.Models
{
    public class Address
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        public string? Neighborhood { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string? Complement { get; set; }
    }
}