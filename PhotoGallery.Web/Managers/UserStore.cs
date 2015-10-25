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
    public class UserStore: IUserStore<User>, IUserRoleStore<User>, IUserPasswordStore<User>, IUserLockoutStore<User, string>, IUserTwoFactorStore<User, string>
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

        public void Create(User user)
        {
            _manager.CreateUser(user);
        }
        public Task DeleteAsync(User user)
        {
            return Task.Run(() => _manager.DeleteUser(user));
        }

        public void Dispose()
        {
            
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var userModel = _manager.FindById(userId);
            if (userModel == null)return Task.FromResult(new User());

            return Task.FromResult(new User(userModel));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var userModel = _manager.FindByName(userName);
            if(userModel == null)return Task.FromResult(new User());

            return Task.FromResult(new User(userModel));
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(_manager.GetPasswordHash(user));
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

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            //TODO
            return null;
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            //TODO
            return Task.Run(() => { return; });
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            //TODO
            return null;            
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            //TODO
            return Task.Run(() => { return; });
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            //TODO
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            //TODO
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            //TODO
            return Task.Run(() => { return; });
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.Run(() => { return; });
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }
    }
}