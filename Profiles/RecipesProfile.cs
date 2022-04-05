using AutoMapper;
using FoodbWebAPI.Models;
using FoodbWebAPI.Dtos;

namespace FoodbWebAPI.Profiles
{
  public class RecipesProfile:Profile
  {
    public RecipesProfile()
    {
      // Source -> target
      CreateMap<Recipe, RecipeReadDto>();
      
      CreateMap<RecipeCreateDto, Recipe>();
      CreateMap<IngredientCreateDto, Ingredient>();

      CreateMap<RecipeUpdateDto, Recipe>();
      CreateMap<IngredientUpdateDto, Ingredient>();
      CreateMap<Recipe, RecipeUpdateDto>();
      CreateMap<Ingredient, IngredientUpdateDto>();
    }
  }
}