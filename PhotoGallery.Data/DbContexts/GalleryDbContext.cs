using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data.DbContexts
{
    public class GalleryDbContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public GalleryDbContext() : base("DefaultConnection") { }
    }
}
