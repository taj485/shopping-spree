namespace ShoppingSpree.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsModels",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductColour = c.String(),
                        ProductPrice = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductsModels");
        }
    }
}
