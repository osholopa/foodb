using System.Collections.Generic;
using FoodbWebAPI.Models;

namespace FoodbWebAPI.Dtos
{
  public class RecipeReadDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Method { get; set; }
    public List<Ingredient> Ingredients { get; set; }
  }
}