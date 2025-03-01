using System.Data.Entity;

public class RecipeContext : DbContext
{
    public RecipeContext() : base("name=RecipeDb")
    {
        this.Configuration.LazyLoadingEnabled = true;
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithRequired(i => i.Recipe) // Specify the navigation property for Ingredients
            .HasForeignKey(i => i.RecipeId) // Explicitly define the foreign key
            .WillCascadeOnDelete(true); // Cascade delete when a Recipe is deleted

        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Steps)
            .WithRequired(s => s.Recipe) // Specify the navigation property for Steps
            .HasForeignKey(s => s.RecipeId) // Explicitly define the foreign key
            .WillCascadeOnDelete(true); // Cascade delete when a Recipe is deleted

        Console.WriteLine("Creating Model");

        base.OnModelCreating(modelBuilder);
    }

}
