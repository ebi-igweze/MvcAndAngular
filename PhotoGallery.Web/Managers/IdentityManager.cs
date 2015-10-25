using PhotoGallery.Data;
using PhotoGallery.Domain;
using PhotoGallery.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Web.Managers
{
    public class IdentityManager
    {
        private IDataRepository _db;

        public IdentityManager(IDataRepository db) { _db = db; }

        public string[] GetRoles()
        {
            return _db.Query<Role>().Select(r => r.RoleName).ToArray();
        }

        public void AddToRole(UserModel userModel, string roleName)
        {
            // get the role that was passed (if it doesnt exist, throw an exception)
            var role = _db.Query<Role>().Where(r => r.RoleName == roleName).FirstOrDefault();
            if (role == null) throw new Exception("Role Does Not Exist");

            // get the user from the model that was passed (if the user does not exist, throw exception)
            var user = _db.Query<User>().Where(u => u.Email == userModel.Email).FirstOrDefault();
            if (user == null) throw new Exception("Invalid User");

            // check if the user already has the role passed in
            var userRole = user.UserRoles.Where(ur => ur.RoleId == role.RoleId).SingleOrDefault();
            if (userRole == null)
            {
                userRole = new UserRole { RoleId = role.RoleId, UserId = user.UserId };
            }

            // add the user's  role to the
            // userRole table and save changes
            _db.Add(userRole);
            _db.SaveChanges();
        }

        public UserModel FindById(string userId)
        {
            int id = int.Parse(userId);
            var user = _db.Query<User>().Where(u => u.UserId == id).FirstOrDefault();
            if (isNull(user)) return null;

            return new UserModel(user);
        }

        // new Implementation
        public UserModel FindByName(string userName)
        {
            var user = _db.Query<User>().Where(u => u.Email == userName).FirstOrDefault();
            if (isNull(user)) return null;

            return new UserModel(user);
        }

        public string[] GetUserRoles(Service.User user)
        {
            // get the user by the email passed in, then get the roles 
            // and select on the list of role names and convert them to array
            return _db.Query<User>().Where(u => u.Email == user.Email).SelectMany(u => u.UserRoles.Select(ur => ur.Role.RoleName)).ToArray();
        }

        // new Implementation
        public bool IsInRole(Service.User user, string roleName)
        {
            return _db.Query<User>().Where(u => u.Email == user.Email).SelectMany(u => u.UserRoles.Select(ur => ur.Role.RoleName)).Contains(roleName);
        }

        //new implementation
        public void RemoveFromRole(Service.User user, string roleName)
        {
            // get the role with the roleName passed
            var role = _db.Query<Role>().Where(r => r.RoleName == roleName).FirstOrDefault();

            // get the UserRole with the user and role values
            var userRole = _db.Query<UserRole>().Where(ur => ur.UserId == user.UserId && ur.RoleId == role.RoleId).SingleOrDefault();

            _db.Delete(userRole);
            _db.SaveChanges();
        }

        // new Implementation
        public void UpdateUser (Service.User user)
        {
            _db.Update(new User(user));
            _db.SaveChanges();
        }

        //new implementation
        public void CreateUser(Service.User user)
        {
            _db.Add(new User(user));
            _db.SaveChanges();

            var savedUser = FindByName(user.Email);
            user.UserId = savedUser.UserId;
            return;
        }

        public string GetPasswordHash(Service.User user)
        {
            return _db.Query<User>().Where(u => u.Email == user.Email).Select(u => u.Password).FirstOrDefault();
        }

        // new Implementation
        public bool HasPasswordHash(Service.User user)
        {
            var currentUser = _db.Query<User>().Where(u => u.Email == user.Email).FirstOrDefault();

            if (currentUser == null) return false;
            return user.Password.Equals(currentUser.Password);
        }


        //new implementation
        public void SetPasswordHash (Service.User user, string passwordHash)
        {
            user.Password = passwordHash;
        }


        //new implementation
        public void DeleteUser(Service.User user)
        {
            _db.Delete(new User(user));
            _db.SaveChanges();
        }
        private bool isNull(object o)
        {
            return o == null;
        }
    }
}