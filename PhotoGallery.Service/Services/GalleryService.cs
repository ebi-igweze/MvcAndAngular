using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Service
{
    public class GalleryService
    {
        private readonly IGalleryManager _gm;

        public GalleryService(IGalleryManager gm) { _gm = gm; }

        public List<Gallery> AllGalleries()
        {
            List<Gallery> newGalleries = new List<Gallery>();

            List<IGallery> galleries= _gm.GetGalleries();

            foreach (var gallery in galleries)
            {
                var gal = new Gallery(gallery);
                newGalleries.Add(gal);
            }

            return newGalleries;
        }
        public Gallery GetGallery(int id)
        {
            return new Gallery(_gm.GetGallery(id));
        }

        public void AddGallery(Gallery gal)
        {
            _gm.AddGallery(gal);
        }

        public void RemoveGallery(Gallery gal)
        {
            _gm.RemoveGallery(gal);
        }

        public void UpdateGallery(Gallery gal)
        {
            _gm.UpdateGallery(gal);
        }

        public void RemovePhoto(Photo photo)
        {
            _gm.RemovePhoto(photo);
        }

        public void AddPhoto(Photo photo)
        {
            _gm.AddPhoto(photo);
        }
    }
}
