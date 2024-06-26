using NomNomNosh.Application.DTOs;
using NomNomNosh.Application.Interfaces;
using NomNomNosh.Domain.Entities;

namespace NomNomNosh.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeDto> CreateRecipe(Guid member_id, Recipe recipe, string username)
        {
            if (recipe.Title.Length < 6)
                throw new ArgumentException("Recipe title must contain at least 6 characters");
            if (recipe.Description.Length < 10)
                throw new ArgumentException("Description must contain at least 10 characters");
            if (recipe.Main_Image == null)
                throw new ArgumentException("A main image is required");

            var newRecipe = await _recipeRepository.CreateRecipe(member_id, recipe, username);

            return newRecipe;
        }

        public async Task<Recipe> GetRecipe(string recipe_slug)
        {
            return await _recipeRepository.GetRecipe(recipe_slug);
        }

        public async Task<ICollection<RecipeDto>> GetRecipes()
        {
            return await _recipeRepository.GetRecipes();
        }

        public async Task<RecipeDto> UpdateRecipe(Guid recipe_id, Guid member_id, Recipe recipe)
        {
            if (recipe.Title.Length < 6)
                throw new ArgumentException("Recipe title must contain at least 6 characters");
            if (recipe.Description.Length < 10)
                throw new ArgumentException("Description must contain at least 10 characters");
            if (recipe.Main_Image == null)
                throw new ArgumentException("A main image is required");

            return await _recipeRepository.UpdateRecipe(recipe_id, member_id, recipe);
        }

        public async Task<RecipeDto> DeleteRecipe(Guid recipe_id, Guid member_id)
        {
            return await _recipeRepository.DeleteRecipe(recipe_id, member_id);
        }
    }
}