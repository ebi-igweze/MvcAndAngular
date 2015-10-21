using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Interface
{
    public interface IGalleryManager
    {
        List<IGallery> GetGalleries();
        void AddGallery(IGallery gal);
        void RemoveGallery(IGallery gal);
        void UpdateGallery(IGallery gal);
        void AddPhoto(IPhoto photo);
        void RemovePhoto(IPhoto photo);
    }
}
