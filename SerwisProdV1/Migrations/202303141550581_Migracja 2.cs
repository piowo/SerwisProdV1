﻿namespace SerwisProdV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String());
        }
    }
}
