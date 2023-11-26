using System.ComponentModel.DataAnnotations;

namespace login_usuario.Data.Dto;

public class CreateUsuarioDto
{
    [Required]
    [StringLength(20, ErrorMessage = "Username ultrapassa o limite de caractere.")]
    public string Username { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}
