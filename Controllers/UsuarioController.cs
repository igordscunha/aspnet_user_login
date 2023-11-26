using System.Threading.Tasks;
using login_usuario.Data.Dto;
using login_usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace login_usuario.Controllers;


[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioDto dto)
    {
        await _usuarioService.CadastrarUsuario(dto);
        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }
}
