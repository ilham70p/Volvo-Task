using Business.Abstract;
using Core.Entity.Models;
using DataAccesss.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleManager:IUserRoleManager
    {
        private readonly IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public void AddDefaultRole(int userId)
        {
            UserRole userRole = new()
            {
                RoleId = 1,
                UserId = userId
            };
            _userRoleDal.Add(userRole);
        }
    }
}
