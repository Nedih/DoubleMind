namespace DoubleMindWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CommentsFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentUserName", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentUserName");
        }
    }
}
