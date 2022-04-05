using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodbWebAPI.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Username { get; set; }

    [Required]
    [JsonIgnore]
    public string PasswordHash { get; set; }

  }
}