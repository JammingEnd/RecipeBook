using System;
using System.Data.Entity.Migrations;

public partial class InitialCreate : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Ingredients",
            c => new
            {
                IngredientId = c.Int(nullable: false, identity: true),
                Name = c.String(),
                Quantity = c.Single(nullable: false),
                Calories = c.Int(nullable: false),
                Unit = c.String(),
                RecipeId = c.Int(nullable: false),
                PlantAlternativeId = c.Int(),
            })
            .PrimaryKey(t => t.IngredientId)
            .ForeignKey("dbo.Ingredients", t => t.PlantAlternativeId)
            .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
            .Index(t => t.RecipeId)
            .Index(t => t.PlantAlternativeId);

        CreateTable(
            "dbo.Recipes",
            c => new
            {
                RecipeId = c.Int(nullable: false, identity: true),
                Name = c.String(),
                Description = c.String(),
            })
            .PrimaryKey(t => t.RecipeId);

        CreateTable(
            "dbo.Steps",
            c => new
            {
                StepId = c.Int(nullable: false, identity: true),
                Description = c.String(),
                Tip = c.String(),
                RecipeId = c.Int(nullable: false),
            })
            .PrimaryKey(t => t.StepId)
            .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
            .Index(t => t.RecipeId);
    }

    public override void Down()
    {
        DropForeignKey("dbo.Steps", "RecipeId", "dbo.Recipes");
        DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
        DropForeignKey("dbo.Ingredients", "PlantAlternativeId", "dbo.Ingredients");
        DropIndex("dbo.Steps", new[] { "RecipeId" });
        DropIndex("dbo.Ingredients", new[] { "PlantAlternativeId" });
        DropIndex("dbo.Ingredients", new[] { "RecipeId" });
        DropTable("dbo.Steps");
        DropTable("dbo.Recipes");
        DropTable("dbo.Ingredients");
    }
}