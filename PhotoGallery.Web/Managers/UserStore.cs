using Microsoft.AspNet.Identity;
using PhotoGallery.Domain;
using PhotoGallery.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoGallery.Web.Managers
{
    public class UserStore: IUserStore<User>, IUserRoleStore<User>, IUserPasswordStore<User>
    {
        private IdentityManager _manager;

        public UserStore(IdentityManager manager)
        {
            _manager = manager;
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            return Task.Run(() => _manager.AddToRole(new UserModel(user), roleName));
        }

        public Task CreateAsync(User user)
        {
           return Task.Run(() => _manager.CreateUser(user));
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => _manager.DeleteUser(user));
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return Task.FromResult(new User(_manager.FindById(userId)));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(new User(_manager.FindByName(userName)));
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            IList<string> userRoles = new List<string>(_manager.GetUserRoles(user));
            return Task.FromResult(userRoles);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(_manager.HasPasswordHash(user));
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return Task.FromResult(_manager.IsInRole(user, roleName));
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            return Task.Run(() => _manager.RemoveFromRole(user, roleName));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => _manager.SetPasswordHash(user, passwordHash));
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => _manager.UpdateUser(user));
        }
    }
}