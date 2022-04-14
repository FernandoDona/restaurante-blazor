using System.ComponentModel.DataAnnotations;

namespace Restaurante.UI.Models;

public class LoginRequest
{
    [Required(ErrorMessage = "O campo usuário é necessário.")]
    public string Username { get; set; }
    [Required(ErrorMessage = "O campo senha é necessário.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
