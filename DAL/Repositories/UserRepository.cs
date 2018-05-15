using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        ShopDbContext context;
        public UserRepository(ShopDbContext context)
        {
            this.context = context;
        }


        public void AddUser(User user)
        {
            context.Users.Add(user);
           Save();
        }

        public bool DeleteUser(string name)
        {
            try
            {
                var _user = FindUserByName(name);
                if (_user!=null)
                {
                    context.Users.Remove(_user);
                    Save();
                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public void Dispose()
        {
            Dispose();
        }

        public User FindUserByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.UserName == name);
        }

        public User FindUserByNameAndPassword(string name, string password)
        {
            return context.Users.Where(u => u.UserName == name&&u.Password==password).FirstOrDefault();
        }

        public IEnumerable<User> GettUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            User _user = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (_user!=null)
            {
                _user.Email = user.Email;
                _user.Password = user.Password;
                _user.ItemsList = user.ItemsList;
            }
        }
        private void Save()
        {
            context.SaveChanges();
        }
    }
}
