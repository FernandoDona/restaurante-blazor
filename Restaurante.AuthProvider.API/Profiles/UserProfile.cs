using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurante.AuthProvider.API.Model;
using Restaurante.AuthProvider.API.Model.Dtos;

namespace Restaurante.AuthProvider.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, IdentityUser<int>>();
    }
}
