using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PhotoGallery.Service
{
    public class User : IUser<string>, IAppUser
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
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        public string[] Roles { get; set; }

        public string Id { get{ return UserId.ToString(); } }

        public string UserName { get { return Email; } set { Email = value; } }

        public User(IAppUser user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            Roles = user.Roles;
        }
        public User(Login user)
        {
            Email = user.Email;
            Password = user.Password;
        }
    }
}
