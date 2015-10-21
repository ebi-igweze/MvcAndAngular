using PhotoGallery.Data.DbContexts;
using PhotoGallery.Domain.Managers;
using PhotoGallery.Data;
using PhotoGallery.Interface;
using PhotoGallery.Service;
using PhotoGallery.Web.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web
{
    public class VGalleryManager
    {
        private static readonly GalleryManager galleryManager = new GalleryManager(new PhotoGalleryManager(new DataRepository(new GalleryDbContext())));
        public static List<Service.Gallery> AllGalleries()
        {
            var galleries = galleryManager.GetGalleries();
            var newGalleries = new List<Service.Gallery>();

            foreach (var gal in galleries)
            {
                var newGallery = new Service.Gallery(gal);
                newGalleries.Add(newGallery);
            }
            return newGalleries;
        }

        public static Service.Gallery GetGallery(int Id)
        {
            return new Service.Gallery( galleryManager.GetGallery(Id));
        }

        public static void AddGallery(Service.Gallery gal)
        {
            galleryManager.AddGallery(gal);
        }
        public static void RemoveGallery(Service.Gallery gal)
        {
            galleryManager.RemoveGallery(gal);
        }

        public static void RemovePhoto(Service.Photo photo)
        {
            galleryManager.RemovePhoto(photo);
        }

        public static void AddPhoto(Service.Photo photo)
        {
            galleryManager.AddPhoto(photo);
        }
    }
}