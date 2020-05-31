namespace DoubleMindWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    CommentId = c.Int(nullable: false, identity: true),
                    CommentText = c.String(),
                    CommentStars = c.Int(nullable: false),
                    CommentUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentUser_Id)
                .Index(t => t.CommentUser_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "CommentUser_Id" });
            DropTable("dbo.Comments");
        }
    }
}
