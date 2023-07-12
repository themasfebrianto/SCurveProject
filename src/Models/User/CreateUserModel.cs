using System.ComponentModel.DataAnnotations;

public class CreateUserModel
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string Role { get; set; } = null!;
}