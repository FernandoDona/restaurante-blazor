using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurante.AuthProvider.API.Model;
using Restaurante.AuthProvider.API.Model.Dtos;

namespace Restaurante.AuthProvider.API.Services;

public class RegisterService
{
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;

    public RegisterService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    internal Task<IdentityResult> RegisterUser(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        var identityUser = _mapper.Map<IdentityUser<int>>(user);

        return _userManager.CreateAsync(identityUser, createUserDto.Password);
    }
}
