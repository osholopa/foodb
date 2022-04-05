using System.Collections.Generic;
using FoodbWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FoodbWebAPI.Dtos;
using FoodbWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace FoodbWebAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepo _repository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/recipes
        [HttpGet]
        public ActionResult<IEnumerable<Models.Recipe>> GetAllRecipes()
        {
            var recipes = _repository.GetAllRecipes();
            return Ok(_mapper.Map<IEnumerable<RecipeReadDto>>(recipes));
        }

        // GET api/recipes/{id}
        [HttpGet("{id}", Name = "GetRecipeById")]
        public ActionResult<Models.Recipe> GetRecipeById(int id)
        {
            var recipe = _repository.GetRecipeById(id);
            if (recipe != null)
            {
                return Ok(_mapper.Map<RecipeReadDto>(recipe));
            }
            return NotFound();
        }

        // POST api/recipes
        [Authorize]
        [HttpPost]
        public ActionResult<RecipeReadDto> CreateRecipe(RecipeCreateDto recipeCreateDto)
        {
            var recipeModel = _mapper.Map<Recipe>(recipeCreateDto);
            _repository.CreateRecipe(recipeModel);
            _repository.SaveChanges();

            var recipeReadDto = _mapper.Map<RecipeReadDto>(recipeModel);
            return CreatedAtRoute(nameof(GetRecipeById), new { Id = recipeReadDto.Id }, recipeReadDto);

        }

        // PUT api/recipes/{id}
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateRecipe(int id, RecipeUpdateDto recipeUpdateDto)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(recipeUpdateDto, recipeModelFromRepo);
            _repository.UpdateRecipe(recipeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // PATCH api/recipes/{id}
        [Authorize]
        [HttpPatch("{id}")]
        public ActionResult PartialRecipeUpdate(int id, JsonPatchDocument<RecipeUpdateDto> patchDoc)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }

            var recipeToPatch = _mapper.Map<RecipeUpdateDto>(recipeModelFromRepo);
            patchDoc.ApplyTo(recipeToPatch, ModelState);

            if (!TryValidateModel(recipeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recipeToPatch, recipeModelFromRepo);
            _repository.UpdateRecipe(recipeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // Delete api/recipes/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteRecipe(int id)
        {
            var recipeModelFromRepo = _repository.GetRecipeById(id);
            if (recipeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRecipe(recipeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}