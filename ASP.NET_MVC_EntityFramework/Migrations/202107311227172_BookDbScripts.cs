namespace ASP.NET_MVC_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookDbScripts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "AuthorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Books", "CoverImage", c => c.String(maxLength: 150));
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "PublisherName", c => c.String());
            AlterColumn("dbo.Books", "CoverImage", c => c.String());
            AlterColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "AuthorName", c => c.String());
            AlterColumn("dbo.Books", "BookName", c => c.String());
        }
    }
}
