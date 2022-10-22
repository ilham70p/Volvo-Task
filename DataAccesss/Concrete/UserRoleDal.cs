using Core.DataAccess.Concrete;
using Core.Entity.Models;
using DataAccesss.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete
{
    public class UserRoleDal:Repository<UserRole,AppDbContext>,IUserRoleDal{


    }
}
