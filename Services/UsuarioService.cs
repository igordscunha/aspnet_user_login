﻿using AutoMapper;
using System.Threading.Tasks;
using login_usuario.Data.Dto;
using login_usuario.Models;
using Microsoft.AspNetCore.Identity;

namespace login_usuario.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CadastrarUsuario(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        var resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }

    }

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado");
        }

        var usuario = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());
    
        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}
