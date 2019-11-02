namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "lastName", c => c.String());
            AddColumn("dbo.Students", "studentCode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "creationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "editDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "editDate");
            DropColumn("dbo.Students", "creationDate");
            DropColumn("dbo.Students", "studentCode");
            DropColumn("dbo.Students", "lastName");
        }
    }
}
