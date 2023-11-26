using AutoMapper;
using login_usuario.Data.Dto;
using login_usuario.Models;

namespace login_usuario.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
