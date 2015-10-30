namespace PhotoGallery.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbContexts.GalleryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoGallery.Data.DbContexts.GalleryDbContext context)
        {
            context.Galleries.AddOrUpdate(g => g.GalleryName, 
                new Gallery { GalleryName = "Pencil Drawings", GalleryDiscription = "Gallery Of Pictures Drawn with just Charcoal and Graphite Pencils", GalleryPhoto = "/Galleries/Pencil Drawings/home.jpg" },
                new Gallery { GalleryName = "Graphic Paintings", GalleryDiscription = "Gallery of Pictures Drawn graphically with software like Photoshop and Illustrator", GalleryPhoto= "/Galleries/Graphic Drawings/home.jpg" },
                new Gallery { GalleryName = "Abstract Paintings", GalleryDiscription = "Gallery of Abstract Paintings of the 17th century through to the 19th Century.",  GalleryPhoto = "/Galleries/Abstract Paintings/home.jpg" },
                new Gallery { GalleryName = "Adult Photography", GalleryDiscription = "R rated Pictures of Exquisite Adult Photography taken by Printerest" , GalleryPhoto = "/Galleries/Adult Photography/home.jpg" }
                );

            context.Photos.AddOrUpdate(p => p.PhotoPath,
                new Photo { PhotoName = "White Bare Bodies", PhotoType = "JPEG", PhotoPath = "/Galleries/Adult PhotoGraphy/nude1.jpg", GalleryId = 4 },
                new Photo { PhotoName = "Black And White Intertwined", PhotoType = "JPEG", PhotoPath = "/Galleries/Adult PhotoGraphy/nude2.jpg", GalleryId = 4 },
                new Photo { PhotoName = "White Female Bare", PhotoType = "JPEG", PhotoPath = "/Galleries/Adult PhotoGraphy/nude3.jpg", GalleryId = 4 },
             
                new Photo { GalleryId = 1, PhotoName = "Female Beauty Charcoal Potrait", PhotoType = "JPEG", PhotoPath = "/Galleries/Pencil Drawings/pencil1.jpg" },
                new Photo { GalleryId = 1, PhotoName = "Sorrowful Soul Charcoal", PhotoType = "JPEG", PhotoPath = "/Galleries/Pencil Drawings/pencil2.jpg" },
                new Photo { GalleryId = 1, PhotoName = "Sailing Ship Charcoal", PhotoType = "JPEG", PhotoPath = "/Galleries/Pencil Drawings/pencil3.jpg" },


                new Photo { GalleryId = 2, PhotoName = "American Indian Princess", PhotoType = "JPEG", PhotoPath = "/Galleries/Graphic Drawings/graphic1.jpg" },
                new Photo { GalleryId = 2, PhotoName = "Lady Hidden Rainbow", PhotoType = "JPEG", PhotoPath = "/Galleries/Graphic Drawings/graphic2.jpg" },
                new Photo { GalleryId = 2, PhotoName = "Comforted Woman", PhotoType = "JPEG", PhotoPath = "/Galleries/Graphic Drawings/graphic3.jpg" },

                new Photo { GalleryId = 3, PhotoName = " Decoupled Handles", PhotoType = "JPEG", PhotoPath = "/Galleries/Abstract Paintings/abstract1.jpg" },
                new Photo { GalleryId = 3, PhotoName = "Bloody Lily Rose", PhotoType = "JPEG", PhotoPath = "/Galleries/Abstract Paintings/abstract2.jpg" },
                new Photo { GalleryId = 3, PhotoName = "Cloud Waves", PhotoType = "JPEG", PhotoPath = "/Galleries/Abstract Paintings/abstract3.jpg" }
                );
            
        }
    }
}
