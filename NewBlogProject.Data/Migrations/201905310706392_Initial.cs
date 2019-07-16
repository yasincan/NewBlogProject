namespace NewBlogProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        PictureId = c.Guid(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.PictureId)
                .Index(t => t.CategoryId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        Description = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Path = c.String(),
                        Title = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "PictureId", "dbo.Pictures");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "PictureId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropTable("dbo.Pictures");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
