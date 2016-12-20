namespace ClassroomManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherStartDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
