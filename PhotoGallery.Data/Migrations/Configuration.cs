namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoGallery.Data.DbContexts.GalleryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoGallery.Data.DbContexts.GalleryDbContext context)
        {

            context.Galleries.AddOrUpdate(
                new Gallery { GalleryName = "Pencil Drawings", GalleryDiscription = "Gallery Of Pictures Drawn with Only Pencil" },
                new Gallery { GalleryName = "Graphic Paintings", GalleryDiscription = "Gallery of Pictures Drawn graphically with software like Photoshop and Illustrator" },
                new Gallery { GalleryName = "Abstract Paintings", GalleryDiscription = "Gallery of Abstract Paintings of the 17th century through to the 19th Century." },
                new Gallery { GalleryName ="Adult Photography", GalleryDiscription ="R rated Pictures of Exquisite Adult Photography taken by Printerest"}
                );

            context.Photos.AddOrUpdate(
                new Photo { PhotoName = "White Bare", PhotoType="JPEG", PhotoPath = "Adult PhotoGraphy/nude1.jpg", GalleryId =4},
                new Photo { PhotoName = "Black And White Bare", PhotoType = "JPEG", PhotoPath = "Adult PhotoGraphy/nude2.jpg", GalleryId = 4 },
                new Photo { PhotoName = "White Female Bare", PhotoType = "JPEG", PhotoPath = "Adult PhotoGraphy/nude3.jpg", GalleryId = 4 }
                );
        }
    }
}
