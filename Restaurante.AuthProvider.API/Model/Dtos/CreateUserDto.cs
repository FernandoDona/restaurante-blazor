using System.ComponentModel.DataAnnotations;

namespace Restaurante.AuthProvider.API.Model.Dtos;

public record CreateUserDto
{
    [Required]
    public string Username { get; init; }
    [Required]
    public string Email { get; init; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; }
    [Required]
    [Compare("Password", ErrorMessage ="Este campo deve ser igual a senha.")]
    public string RePassword { get; init; }
}
