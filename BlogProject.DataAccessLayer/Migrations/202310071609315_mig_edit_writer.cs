namespace BlogProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_writer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterRole");
            DropColumn("dbo.Writers", "WriterStatus");
            DropColumn("dbo.Writers", "WriterTitle");
        }
    }
}
