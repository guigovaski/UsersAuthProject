using System.ComponentModel.DataAnnotations;

namespace UsersAuth.Dtos;

public class CreateUserDto
{
    [Required]
    [StringLength(200)]
    public string Username { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string PasswordValidation { get; set; }
}
