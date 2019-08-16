namespace NewBlogProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtrticleModelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Text", c => c.String());
        }
    }
}
