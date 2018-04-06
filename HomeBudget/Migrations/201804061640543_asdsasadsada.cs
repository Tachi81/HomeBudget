namespace HomeBudget.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsasadsada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "Category_Id" });
            RenameColumn(table: "dbo.SubCategories", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.SubCategories", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            AlterColumn("dbo.SubCategories", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.SubCategories", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.SubCategories", "Category_Id");
            AddForeignKey("dbo.SubCategories", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
