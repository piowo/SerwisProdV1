namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "SearchHistory_Id", "dbo.SearchHistories");
            DropForeignKey("dbo.Modules", "SearchHistory_Id", "dbo.SearchHistories");
            DropIndex("dbo.Cities", new[] { "SearchHistory_Id" });
            DropIndex("dbo.Modules", new[] { "SearchHistory_Id" });
            DropColumn("dbo.Cities", "SearchHistory_Id");
            DropColumn("dbo.Modules", "SearchHistory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "SearchHistory_Id", c => c.Int());
            AddColumn("dbo.Cities", "SearchHistory_Id", c => c.Int());
            CreateIndex("dbo.Modules", "SearchHistory_Id");
            CreateIndex("dbo.Cities", "SearchHistory_Id");
            AddForeignKey("dbo.Modules", "SearchHistory_Id", "dbo.SearchHistories", "Id");
            AddForeignKey("dbo.Cities", "SearchHistory_Id", "dbo.SearchHistories", "Id");
        }
    }
}
