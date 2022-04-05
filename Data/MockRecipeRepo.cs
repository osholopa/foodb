using System.Collections.Generic;
using FoodbWebAPI.Models;

namespace FoodbWebAPI.Data
{
  public class MockRecipeRepo : IRecipeRepo
  {
    public void CreateRecipe(Recipe recipe)
    {
      throw new System.NotImplementedException();
    }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Recipe> GetAllRecipes()
    {
      var recipes = new List<Recipe>
      {
        new Recipe
      {
        Id = 0,
        Name = "Viiden minuutin muna",
        Method = "Keitä munaa 5 min.",
        Ingredients = new List<Ingredient> { new Ingredient { Id = 0, Amount = "1", Description = "Vapaan kanan muna" } }
      },
      new Recipe
      {
        Id = 1,
        Name = "Makarooni ja ketsuppi",
        Method = "Keitä makaroneja 8 min. Lisää ketsuppi. Sekoita",
        Ingredients = new List<Ingredient> {
          new Ingredient { Id = 1, Amount = "400 g", Description = "Tummaa makaronia" },
          new Ingredient { Id = 2, Amount = "1 dl", Description = "Ketsuppia" },
        }
      },
      new Recipe
      {
        Id = 2,
        Name = "Makrojen sinfonia",
        Method = "Keitä makaroneja 8 min. Paista kanat ja parsakaalit. Sekoita",
        Ingredients = new List<Ingredient> {
          new Ingredient { Id = 3, Amount = "400 g", Description = "Tummaa makaronia" },
          new Ingredient { Id = 4, Amount = "1 kpl", Description = "Parsakaalia" },
          new Ingredient { Id = 5, Amount = "300 g", Description = "Kanan fileesuikaleita" },
        }
      }
      };
      return recipes;
    }

    public Recipe GetRecipeById(int id)
    {
      return new Recipe
      {
        Id = 0,
        Name = "Viiden minuutin muna",
        Method = "Keitä munaa 5 min.",
        Ingredients = new List<Ingredient> { new Ingredient { Id = 0, Amount = "1", Description = "Vapaan kanan muna" } }
      };
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

        public void UpdateRecipe(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}