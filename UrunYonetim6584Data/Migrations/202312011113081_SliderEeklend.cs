namespace UrunYonetim6584Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SliderEeklend : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "IsHome", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsHome");
            DropTable("dbo.Slides");
        }
    }
}
