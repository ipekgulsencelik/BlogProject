namespace BlogProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_vitrin_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScreenShots",
                c => new
                    {
                        ScreenShotID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ScreenShotID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 100),
                        SkillDetails = c.String(),
                        SkillLevel = c.Byte(nullable: false),
                        TalentID = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("dbo.Talents", t => t.TalentID)
                .Index(t => t.TalentID);
            
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentName = c.String(maxLength: 100),
                        TalentDetails = c.String(),
                    })
                .PrimaryKey(t => t.TalentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "TalentID", "dbo.Talents");
            DropIndex("dbo.Skills", new[] { "TalentID" });
            DropTable("dbo.Talents");
            DropTable("dbo.Skills");
            DropTable("dbo.ScreenShots");
        }
    }
}
