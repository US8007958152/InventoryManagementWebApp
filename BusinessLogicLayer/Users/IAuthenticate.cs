using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Users
{
    public interface IAuthenticate
    {
        int Validate(string userName, string password);
    }
}
