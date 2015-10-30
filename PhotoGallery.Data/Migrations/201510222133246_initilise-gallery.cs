namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initilisegallery : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "PhotoName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "PhotoName", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
