using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    public class Role
    { 
        public int RoleId { get; set; }
        [Required]
        [MaxLength(10)]
        public string RoleName { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }
    }
}
