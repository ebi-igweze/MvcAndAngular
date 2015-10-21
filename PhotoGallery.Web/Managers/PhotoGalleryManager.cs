using PhotoGallery.Data;
using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web.Managers
{
    public class PhotoGalleryManager : IGalleryManager
    {

        private IDataRepository _db;
        public PhotoGalleryManager(IDataRepository db)
        {
            _db = db;
        }


        public List<IGallery> GetGalleries()
        {
            var galleries = _db.Query<Gallery>().Select(g => g).ToList();
            List<IGallery> newGalleries = new List<IGallery>();

            foreach (var gallery in galleries)
            {
                newGalleries.Add(gallery);
            }
            return newGalleries;
        }

        public IGallery GetGallery(int Id)
        {
            return _db.GetByID<Gallery>(Id);
        }

        public void AddGallery(IGallery gallery)
        {
            Gallery gal = new Gallery(gallery);
            _db.Add(gal);
            _db.SaveChanges();
        }

        public void RemoveGallery(IGallery gallery)
        {
            Gallery gal = new Gallery(gallery);
            _db.Delete(gal);
            _db.SaveChanges();
        }

        public void UpdateGallery(IGallery gallery)
        {
            Gallery gal = new Gallery(gallery);
            _db.Update(gal);
            _db.SaveChanges();
        }

        public void AddPhoto(IPhoto photo)
        {
            var p = new Photo(photo);
            _db.Update(p);
            _db.SaveChanges();
        }

        public void RemovePhoto(IPhoto photo)
        {
            var p = new Photo(photo);
            _db.Delete(p);
            _db.SaveChanges();
        }
    }
}