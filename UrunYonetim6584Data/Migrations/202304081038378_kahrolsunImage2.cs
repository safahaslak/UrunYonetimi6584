namespace UrunYonetim6584Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kahrolsunImage2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Brand = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(maxLength: 100),
                        Image2 = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
