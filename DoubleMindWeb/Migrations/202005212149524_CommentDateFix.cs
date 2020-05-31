﻿namespace DoubleMindWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CommentDateFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentCreated", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentCreated");
        }
    }
}
