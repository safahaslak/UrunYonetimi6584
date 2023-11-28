namespace UrunYonetim6584Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
