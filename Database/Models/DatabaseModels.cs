
public class Recipe
{
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Step> Steps { get; set; }
}

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public float Quantity { get; set; }

    public string Unit { get; set; }
}

public class Step
{
    public int StepId { get; set; }
    public string Description { get; set; }
}