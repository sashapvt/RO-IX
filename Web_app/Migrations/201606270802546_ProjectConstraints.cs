namespace Web_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Projects", "ProjectComment", c => c.String(maxLength: 255));
            AlterColumn("dbo.Projects", "BoilerName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "BoilerName", c => c.String());
            AlterColumn("dbo.Projects", "ProjectComment", c => c.String());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
        }
    }
}
