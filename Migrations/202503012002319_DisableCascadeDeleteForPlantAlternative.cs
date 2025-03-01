namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableCascadeDeleteForPlantAlternative : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ingredients", new[] { "PlantAlternative_IngredientId" });
            DropColumn("dbo.Ingredients", "PlantAlternativeId");
            RenameColumn(table: "dbo.Ingredients", name: "PlantAlternative_IngredientId", newName: "PlantAlternativeId");
            AlterColumn("dbo.Ingredients", "PlantAlternativeId", c => c.Int());
            CreateIndex("dbo.Ingredients", "PlantAlternativeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ingredients", new[] { "PlantAlternativeId" });
            AlterColumn("dbo.Ingredients", "PlantAlternativeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ingredients", name: "PlantAlternativeId", newName: "PlantAlternative_IngredientId");
            AddColumn("dbo.Ingredients", "PlantAlternativeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingredients", "PlantAlternative_IngredientId");
        }
    }
}
