using System.ComponentModel.DataAnnotations;

namespace login_usuario.Data.Dto;

public class LoginUsuarioDto
{

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
