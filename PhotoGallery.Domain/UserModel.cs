using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Domain
{
    public class UserModel : IAppUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string [] Roles { get; set; }

        public UserModel (IAppUser user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Email = user.Email;
            Roles = user.Roles;
        }
    }
}
