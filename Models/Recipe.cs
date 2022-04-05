using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodbWebAPI.Models
{
  public class Recipe
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    [Required]
    public string Method { get; set; }

    [Required]
    public virtual ICollection<Ingredient> Ingredients { get; set; }
  }
}