using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Users
{
    public interface IUser
    {
        int Add(User user);
        bool Update(User user);
        bool Delete(int userId);
        User GetUser(int userId);
        List<User> GetUsers();
    }
}
