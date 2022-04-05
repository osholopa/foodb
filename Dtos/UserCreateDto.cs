using System.ComponentModel.DataAnnotations;

namespace FoodbWebAPI.Models
{
  public class UserCreateDto
  {
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

  }
}