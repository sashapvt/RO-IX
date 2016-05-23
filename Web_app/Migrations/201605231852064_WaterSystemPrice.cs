namespace Web_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WaterSystemPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "WaterROSystemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Projects", "WaterIXSystemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "WaterIXSystemPrice");
            DropColumn("dbo.Projects", "WaterROSystemPrice");
        }
    }
}
