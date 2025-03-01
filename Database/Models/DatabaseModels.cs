
public class Recipe
{
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Ingredients are based on 1 person
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<Step> Steps { get; set; } = new List<Step>();
}

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public float Quantity { get; set; }

    public string Unit { get; set; }

    // Foreign key
    public int RecipeId { get; set; }
    public virtual Recipe Recipe { get; set; }
}

public class Step
{
    public int StepId { get; set; }
    public string Description { get; set; }

    // Foreign key
    public int RecipeId { get; set; }
    public virtual Recipe Recipe { get; set; }
}

public enum Units
{
    Gram,
    Kilo,
    Mililiter,
    Liter,
    Piece,
    TeaSpoon,
    EatingSpoon,
}