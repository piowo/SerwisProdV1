namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SearchHistories", "ModuleName1", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SearchHistories", "ModuleName1", c => c.String());
        }
    }
}
