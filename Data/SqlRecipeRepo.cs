using System;
using System.Collections.Generic;
using System.Linq;
using FoodbWebAPI.Models;

namespace FoodbWebAPI.Data
{
    public class SqlRecipeRepo : IRecipeRepo
    {
        private readonly FooDBContext _context;

        public SqlRecipeRepo(FooDBContext context)
        {
            _context = context;
        }

        public void CreateRecipe(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            _context.Recipes.Add(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            _context.Ingredients.RemoveRange(recipe.Ingredients);
            _context.Recipes.Remove(recipe);
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            var recipelist = _context.Recipes.ToList();
            foreach (Recipe r in recipelist)
            {
                _context.Entry(r).Collection(r => r.Ingredients).Load();
            }
            return recipelist;
        }

        public Recipe GetRecipeById(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(recipe => recipe.Id == id);
            if (recipe != null)
            {
                _context.Entry(recipe).Collection(r => r.Ingredients).Load();
            }
            return recipe;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}