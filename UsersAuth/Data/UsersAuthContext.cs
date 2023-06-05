using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersAuth.Models;

namespace UsersAuth.Data;

public class UsersAuthContext : IdentityDbContext<User>
{
    public UsersAuthContext(DbContextOptions<UsersAuthContext> opts)
        : base(opts)
    {
    }
}
