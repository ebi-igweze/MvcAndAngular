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
        [MaxLength(15)]
        public string PhotoName { get; set; }
        [Required]
        [MaxLength(5)]
        public string PhotoType { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}
