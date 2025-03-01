

using System.Data.Entity;

public class DbInteractor
{
    private RecipeContext _context;

    public DbInteractor()
    {
        _context = new RecipeContext();
    }

    public void AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public Recipe GetRecipe(int id)
    {
        Recipe recipe = _context.Recipes.Find(id);
        recipe.Ingredients = GetIngredientsForRecipe(id);
        recipe.Steps = GetStepsForRecipe(id);
        return recipe;
    }

    public List<Recipe> GetAllRecipes()
    {
        Recipe[] recipes = _context.Recipes.ToArray();
        foreach (Recipe recipe in recipes)
        {
            recipe.Ingredients = GetIngredientsForRecipe(recipe.RecipeId);
            recipe.Steps = GetStepsForRecipe(recipe.RecipeId);
        }
        return recipes.ToList();
    }

    public void UpdateRecipe(Recipe recipe)
    {
        _context.Entry(recipe).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteRecipe(int id)
    {
        Recipe recipe = _context.Recipes.Find(id);
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }

    #region Ingredients

    public List<Ingredient> GetIngredientsForRecipe(int recipeId)
    {
        return _context.Ingredients.Where(i => i.RecipeId == recipeId).ToList();
    }

    #endregion

    #region Steps

    public List<Step> GetStepsForRecipe(int recipeId)
    {
        return _context.Steps.Where(s => s.RecipeId == recipeId).ToList();
    }

    #endregion
}
