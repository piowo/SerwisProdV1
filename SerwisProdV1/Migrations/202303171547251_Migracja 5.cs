namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchHistories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SearchHistories", "Name");
        }
    }
}
