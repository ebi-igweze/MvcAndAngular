using PhotoGallery.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PhotoGallery.Domain.Managers
{
    public class GalleryManager:IGalleryManager
    {
        private IDataRepository _db;
        public GalleryManager(IDataRepository db)
        {
            _db = db;
        }

        public List<GalleryModel> GetGalleries()
        {
            var galleries =  _db.Query<IGallery>().Select(g => g).ToList();
            List<GalleryModel> newGalleries = new List<GalleryModel>();

            foreach (var gallery in galleries)
            {
                var newGallery = new GalleryModel(gallery);
                newGalleries.Add(newGallery);
            }
            return newGalleries;
        }

        public IGallery GetGallery(int Id)
        {
            return _db.GetByID<IGallery>(Id);
        }

        public void AddGallery(IGallery gallery)
        {
            _db.Add(gallery);
            _db.SaveChanges();
        }

        public void RemoveGallery(IGallery gallery)
        {
            _db.Delete(gallery);
            _db.SaveChanges();
        }

        public void UpdateGallery(IGallery gallery)
        {
            _db.Update(gallery);
            _db.SaveChanges();
        }

        public void AddPhoto(IPhoto photo)
        {
            _db.Update(photo);
            _db.SaveChanges();
        }

        public void RemovePhoto(IPhoto photo)
        {
            _db.Delete(photo);
            _db.SaveChanges();
        }

        List<IGallery> IGalleryManager.GetGalleries()
        {
            List<GalleryModel> gals = GetGalleries();
            List<IGallery> newGalleries = new List<IGallery>();

            foreach (var gallery in gals)
            {
                newGalleries.Add(gallery);
            }
            return newGalleries;
        }
    }
}
