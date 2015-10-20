
using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Data
{
    public class User : IAppUser
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public string[] Roles
        {
            get
            {
                return null;
            }
        }
        
    }
}
