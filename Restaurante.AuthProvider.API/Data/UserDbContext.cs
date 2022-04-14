using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.AuthProvider.API.Data;

public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
