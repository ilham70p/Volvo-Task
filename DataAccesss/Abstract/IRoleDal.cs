using Core.DataAccess.Abstract;
using Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Abstract
{
    public interface IRoleDal:IRepository<Role>
    {
        Role GetUserRole(int userId);
    }
}
