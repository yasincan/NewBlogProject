namespace NewBlogProject.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ResourceTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
        }
    }
}
