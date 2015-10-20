using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Interface
{
    public interface IGallery
    {
        int GalleryId { get; set; }
        string GalleryName { get; set; }
        string GalleryDiscription { get; set; }
        List<IPhoto> GalleryPhotos{ get; }
    }
}
