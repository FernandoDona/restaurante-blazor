using System.ComponentModel.DataAnnotations;

namespace Restaurante.AuthProvider.API.Model;

public record LoginRequest([Required]string Username, [Required]string Password);
