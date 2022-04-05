using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodbWebAPI.Dtos
{
  public class RecipeCreateDto
  {
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    [Required]
    public string Method { get; set; }
    [Required]
    public ICollection<IngredientCreateDto> Ingredients {get; set;}
  }

  public class IngredientCreateDto
  {
    [Required]
    public string Amount { get; set; }
    [Required]
    public string Description { get; set; }
  }
}