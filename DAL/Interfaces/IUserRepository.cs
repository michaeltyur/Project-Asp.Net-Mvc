using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository:IDisposable
    {
        void AddUser(User item);

        void UpdateUser(User user);

        bool DeleteUser(string name);

        IEnumerable<User> GettUsers();

        User FindUserByName(string name);

        User FindUserByNameAndPassword(string name,string password);

        
    }
}
