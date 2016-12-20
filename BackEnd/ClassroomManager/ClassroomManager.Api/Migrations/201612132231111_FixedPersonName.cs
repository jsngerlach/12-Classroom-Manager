namespace ClassroomManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedPersonName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.Int(nullable: false));
        }
    }
}
