namespace BlogProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_image_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageFileID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 500),
                        ImageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageFileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
