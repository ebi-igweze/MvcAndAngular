using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Service
{
    public class Gallery : IGallery
    {
        public int  GalleryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string GalleryName { get; set; }
        [Required]
        public string GalleryDiscription { get; set; }
        [Required]
        public string GalleryPhoto { get; set; }
        public List<IPhoto> GalleryPhotos { get; set; }

        public Gallery() { GalleryPhotos = new List<IPhoto>(); }
        public Gallery(IGallery gallery)
        {
            GalleryId = gallery.GalleryId;
            GalleryName = gallery.GalleryName;
            GalleryDiscription = gallery.GalleryDiscription;
            GalleryPhoto = gallery.GalleryPhoto;
            GalleryPhotos = gallery.GalleryPhotos;
        }
    }
}
