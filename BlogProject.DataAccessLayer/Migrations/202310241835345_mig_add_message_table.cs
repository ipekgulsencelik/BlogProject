namespace BlogProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_message_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(maxLength: 50),
                        ReceiverMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                        Trash = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsImportant = c.Boolean(nullable: false),
                        IsSpam = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
