namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGallery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "GalleryPhoto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "GalleryPhoto");
        }
    }
}
