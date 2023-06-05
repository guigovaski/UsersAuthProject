using AutoMapper;
using UsersAuth.Dtos;
using UsersAuth.Models;

namespace UsersAuth.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}
