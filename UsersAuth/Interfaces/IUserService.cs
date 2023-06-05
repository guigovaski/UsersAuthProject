using Microsoft.AspNetCore.Identity;
using UsersAuth.Dtos;

namespace UsersAuth.Interfaces;

public interface IUserService
{
    public async Task CreateUserAsync(CreateUserDto userDto) { }
    public Task<string> LoginUserAsync(LoginUserDto userDto);
}
