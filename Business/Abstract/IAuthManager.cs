using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        void Register(DtoRegister model);
        User GetUserByEmail(string email);
        User Login(string email);
        //List<User> GetUsers();
    }
}
