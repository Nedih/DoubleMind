namespace DoubleMindWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Game : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserLevel", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserPoints");
            DropColumn("dbo.AspNetUsers", "UserLevel");
        }
    }
}
