using System.Collections.Generic;
using FoodbWebAPI.Models;

namespace FoodbWebAPI.Data
{
  public interface IRecipeRepo
  {
    bool SaveChanges();
    IEnumerable<Recipe> GetAllRecipes();
    Recipe GetRecipeById(int id);
    void CreateRecipe(Recipe recipe);
    void UpdateRecipe(Recipe recipe);
    void DeleteRecipe(Recipe recipe);
  }
}