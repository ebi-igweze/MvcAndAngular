namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialGallery : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "GalleryName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "GalleryName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
