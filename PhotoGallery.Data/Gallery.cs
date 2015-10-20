using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    class Gallery : IGallery
    {
        public int GalleryId { get; set; }
        public string GalleryName { get; set; }
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
    }
}
