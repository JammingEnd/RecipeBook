using System.Data.Entity;

public class RecipeContext : DbContext
{
    public RecipeContext() : base("name=RecipeDb")
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithRequired()
            .WillCascadeOnDelete(true);

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Steps)
            .WithRequired()
            .WillCascadeOnDelete(true);

        Console.WriteLine("Creating Model");

        base.OnModelCreating(modelBuilder);
    }
    
}
