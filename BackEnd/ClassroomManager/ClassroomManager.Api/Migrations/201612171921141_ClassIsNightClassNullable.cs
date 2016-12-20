namespace ClassroomManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassIsNightClassNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "IsNightClass", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "IsNightClass", c => c.Boolean(nullable: false));
        }
    }
}
