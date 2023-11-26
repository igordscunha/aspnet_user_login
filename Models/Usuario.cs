using Microsoft.AspNetCore.Identity;

namespace login_usuario.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public Usuario(): base() { }
}
