namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modules", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Modules", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "Description", c => c.String());
            AlterColumn("dbo.Modules", "Name", c => c.String());
            AlterColumn("dbo.Modules", "Code", c => c.String());
        }
    }
}
