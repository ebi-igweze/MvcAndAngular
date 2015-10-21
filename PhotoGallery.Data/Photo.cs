using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    public class Photo: IPhoto
    {
        public int PhotoId { get; set; }
        [Required]
        [MaxLength(25)]
        public string PhotoName { get; set; }
        [Required]
        [MaxLength(5)]
        public string PhotoType { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        public int GalleryId { get; set; }

        public Photo(IPhoto photo)
        {
            PhotoId = photo.PhotoId;
            PhotoName = photo.PhotoName;
            PhotoType = photo.PhotoType;
            PhotoPath = photo.PhotoPath;
            GalleryId = photo.GalleryId;
        }
        public Photo() { }
    }
}
