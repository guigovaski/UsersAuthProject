using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using UsersAuth.Dtos;
using UsersAuth.Interfaces;
using UsersAuth.Models;

namespace UsersAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> CreateUser(CreateUserDto userDto)
    {
        try
        {
            await _userService.CreateUserAsync(userDto);
            return Ok("Usuário cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser(LoginUserDto userDto)
    {
        try
        {
            string jwtToken = await _userService.LoginUserAsync(userDto);
            return Ok(jwtToken);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
