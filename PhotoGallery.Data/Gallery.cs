using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    public class Gallery : IGallery
    {
        [Key]
        public int GalleryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string GalleryName { get; set; }
        [Required]
        public string GalleryDiscription { get; set; }
        public virtual List<Photo> Photos { get; set;}

       public List<IPhoto> GalleryPhotos
        {
            get
            {
                List<IPhoto> gPhotos = new List<IPhoto>();
                foreach (var photo in Photos)
                {
                    IPhoto currentPhoto = photo;
                    gPhotos.Add(currentPhoto);
                }
                return gPhotos;
            }
        }

        public Gallery()
        {
            Photos = new List<Photo>();
        }
        public Gallery(IGallery gallery)
        {
            GalleryName = gallery.GalleryName;
            GalleryDiscription = gallery.GalleryDiscription;
        }
    }
}
