

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
        return _context.Recipes.Find(id);
    }

    public List<Recipe> GetAllRecipes()
    {
        return _context.Recipes.ToList();
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
}
