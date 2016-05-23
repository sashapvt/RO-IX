namespace Web_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UF = c.Single(nullable: false),
                        RO = c.Single(nullable: false),
                        IX1 = c.Single(nullable: false),
                        IX2 = c.Single(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectCurRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProjectComment = c.String(),
                        ProjectDate = c.DateTime(nullable: false),
                        BoilerName = c.String(),
                        BolerPower = c.Single(nullable: false),
                        BoilerProductivity = c.Single(nullable: false),
                        BoilerPressure = c.Single(nullable: false),
                        BoilerEfficiency = c.Single(nullable: false),
                        BoilerAnnnualLoad = c.Single(nullable: false),
                        WaterInConductivity = c.Single(nullable: false),
                        WaterInHardness = c.Single(nullable: false),
                        WaterInTemperature = c.Single(nullable: false),
                        WaterCondensateReturn = c.Single(nullable: false),
                        WaterCondensateConductivity = c.Single(nullable: false),
                        WaterCondensateTemperature = c.Single(nullable: false),
                        WaterROConductivity = c.Single(nullable: false),
                        WaterROConductivityMax = c.Single(nullable: false),
                        WaterIXConductivity = c.Single(nullable: false),
                        WaterIXConductivityMax = c.Single(nullable: false),
                        OptionsRORawProductivity = c.Single(nullable: false),
                        OptionsROUFOn = c.Boolean(nullable: false),
                        OptionsROUFPermeate = c.Single(nullable: false),
                        OptionsROUFProductivity = c.Single(nullable: false),
                        OptionsROROOn = c.Boolean(nullable: false),
                        OptionsROROPermeate = c.Single(nullable: false),
                        OptionsROROProductivity = c.Single(nullable: false),
                        OptionsROIXOn = c.Boolean(nullable: false),
                        OptionsROIXPermeate = c.Single(nullable: false),
                        OptionsROIXProductivity = c.Single(nullable: false),
                        OptionsROEditOn = c.Boolean(nullable: false),
                        OptionsIXRawProductivity = c.Single(nullable: false),
                        OptionsIXUFOn = c.Boolean(nullable: false),
                        OptionsIXUFPermeate = c.Single(nullable: false),
                        OptionsIXUFProductivity = c.Single(nullable: false),
                        OptionsIXIX1On = c.Boolean(nullable: false),
                        OptionsIXIX1Permeate = c.Single(nullable: false),
                        OptionsIXIX1Productivity = c.Single(nullable: false),
                        OptionsIXIX2On = c.Boolean(nullable: false),
                        OptionsIXIX2Permeate = c.Single(nullable: false),
                        OptionsIXIX2Productivity = c.Single(nullable: false),
                        OptionsIXEditOn = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Projects", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectPrices", "Project_Id", "dbo.Projects");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Projects", new[] { "User_Id" });
            DropIndex("dbo.ProjectPrices", new[] { "Project_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectPrices");
        }
    }
}
