namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAmountFromFramework_ForReal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "PrepareAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "PrepareAmount", c => c.Int(nullable: false));
        }
    }
}
