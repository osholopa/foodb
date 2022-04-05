using System.ComponentModel.DataAnnotations;

namespace FoodbWebAPI.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    [Required]
    public string Amount { get; set; }
    [Required]
    public string Description { get; set; }
  }
}