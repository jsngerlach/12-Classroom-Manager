namespace ClassroomManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTelephone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Telephone", c => c.String());
            AddColumn("dbo.Teachers", "Telephone", c => c.String());
            DropColumn("dbo.Students", "Telepone");
            DropColumn("dbo.Teachers", "Telepone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Telepone", c => c.String());
            AddColumn("dbo.Students", "Telepone", c => c.String());
            DropColumn("dbo.Teachers", "Telephone");
            DropColumn("dbo.Students", "Telephone");
        }
    }
}
