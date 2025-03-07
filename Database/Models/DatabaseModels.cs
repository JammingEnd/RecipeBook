
using System.ComponentModel.DataAnnotations.Schema;

public class Recipe
{
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [NotMapped]
    public int PrepareAmount { get; set; } = 1; // default is 1

    // Ingredients are based on 1 person
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public List<Step> Steps { get; set; } = new List<Step>();
}

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public float Quantity { get; set; }
    public int Calories { get; set; } // Kcal
    public string Unit { get; set; }

    // Foreign key
    public int RecipeId { get; set; }
    public virtual Recipe Recipe { get; set; }

    public int? PlantAlternativeId { get; set; }
    public virtual Ingredient PlantAlternative { get; set; }
}

public class Step
{
    public int StepId { get; set; }
    public string Description { get; set; }
    public string Tip { get; set; }

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