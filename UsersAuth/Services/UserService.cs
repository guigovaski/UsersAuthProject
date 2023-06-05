using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using UsersAuth.Dtos;
using UsersAuth.Interfaces;
using UsersAuth.Models;

namespace UsersAuth.Services;

public class UserService : IUserService
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private IMapper _mapper;
    private ITokenService _tokenService;

    public UserService(UserManager<User> userManager, IMapper mapper, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    public async Task CreateUserAsync(CreateUserDto userDto)
    {
        var userMapped = _mapper.Map<User>(userDto);
        var result = await _userManager.CreateAsync(userMapped, userDto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Não foi possível cadastrar o usuário");
        }
    }

    public async Task<string> LoginUserAsync(LoginUserDto userDto)
    {
        var signInResult = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);
        if (!signInResult.Succeeded)
        {
            throw new ApplicationException("Não foi possível fazer o login do usuário");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userDto.Username.ToUpper());
        
        var jwtToken = _tokenService.GenerateToken(user);
        return jwtToken;
    }
}
