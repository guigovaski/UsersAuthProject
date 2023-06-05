using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsersAuth.Models;

public class User : IdentityUser
{
    [Required]
    public DateTime DateOfBirth { get; set; }
    public User() : base()
    {
    }
}
