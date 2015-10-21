using PhotoGallery.Interface;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PhotoGallery.Domain.Managers
{
    public class GalleryManager
    {
        private readonly IGalleryManager _gm;
        public GalleryManager(IGalleryManager gm) { _gm = gm; }

        public void AddGallery(IGallery gal)
        {
            _gm.AddGallery(gal);
        }

        public void AddPhoto(IPhoto photo)
        {
            _gm.AddPhoto(photo);
        }

        public List<GalleryModel> GetGalleries()
        {
            var Igalleries = _gm.GetGalleries();
            var newGalleries = new List<GalleryModel>();
            foreach (var gal in Igalleries)
            {
                var newGallery = new GalleryModel(gal);
                newGalleries.Add(newGallery);
            }

            return newGalleries;
        }

        public IGallery GetGallery(int Id)
        {
            return _gm.GetGallery(Id);
        }

        public void RemoveGallery(IGallery gal)
        {
            _gm.RemoveGallery(gal);
        }

        public void RemovePhoto(IPhoto photo)
        {
            _gm.RemovePhoto(photo);
        }

        public void UpdateGallery(IGallery gal)
        {
            _gm.UpdateGallery(gal);
        }
    }
}
