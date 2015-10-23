using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public class GalleryModel:IGallery
    {
        public int GalleryId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryDiscription { get; set; }
        public string GalleryPhoto { get; set; }
        public List<IPhoto> GalleryPhotos { get; set; }
        
        public GalleryModel(IGallery gallery)
        {
            GalleryId = gallery.GalleryId;
            GalleryName = gallery.GalleryName;
            GalleryDiscription = gallery.GalleryDiscription;
            GalleryPhoto = gallery.GalleryPhoto;
            GalleryPhotos = gallery.GalleryPhotos;
        }
    }
}
