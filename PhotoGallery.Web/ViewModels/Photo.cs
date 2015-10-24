using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Service
{
    public class Photo:IPhoto
    {
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoType { get; set; }
        public string PhotoPath { get; set; }
        public int GalleryId { get; set; }
    }
}
