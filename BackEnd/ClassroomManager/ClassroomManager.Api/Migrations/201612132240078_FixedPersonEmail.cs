namespace ClassroomManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedPersonEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "EmailAddress", c => c.String());
            AlterColumn("dbo.Teachers", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "EmailAddress", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "EmailAddress", c => c.Int(nullable: false));
        }
    }
}
