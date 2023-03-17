namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SearchHistories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SearchHistories", "Name", c => c.String());
        }
    }
}
