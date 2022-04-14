using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.Models;

public class RegisterUserRequest
{
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    [Compare("Password", ErrorMessage = "Este campo deve ser igual a senha.")]
    [DataType(DataType.Password)]
    public string RePassword { get; set; }
}
