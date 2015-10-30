namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initilagallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        GalleryName = c.String(nullable: false, maxLength: 30),
                        GalleryDiscription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        PhotoName = c.String(nullable: false, maxLength: 25),
                        PhotoType = c.String(nullable: false, maxLength: 5),
                        PhotoPath = c.String(nullable: false),
                        GalleryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.Photos", new[] { "GalleryId" });
            DropTable("dbo.Photos");
            DropTable("dbo.Galleries");
        }
    }
}
