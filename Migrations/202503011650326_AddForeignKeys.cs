namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ingredients", name: "Recipe_RecipeId", newName: "RecipeId");
            RenameColumn(table: "dbo.Steps", name: "Recipe_RecipeId", newName: "RecipeId");
            RenameIndex(table: "dbo.Ingredients", name: "IX_Recipe_RecipeId", newName: "IX_RecipeId");
            RenameIndex(table: "dbo.Steps", name: "IX_Recipe_RecipeId", newName: "IX_RecipeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Steps", name: "IX_RecipeId", newName: "IX_Recipe_RecipeId");
            RenameIndex(table: "dbo.Ingredients", name: "IX_RecipeId", newName: "IX_Recipe_RecipeId");
            RenameColumn(table: "dbo.Steps", name: "RecipeId", newName: "Recipe_RecipeId");
            RenameColumn(table: "dbo.Ingredients", name: "RecipeId", newName: "Recipe_RecipeId");
        }
    }
}
