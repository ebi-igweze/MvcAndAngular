using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Interface
{
    public interface IPhoto
    {
        int PhotoId { get; set; }
        string PhotoName { get; set; }
        string PhotoType { get; set; }
        string PhotoPath { get; set; }
        int GalleryId { get; set; }
    }
}
