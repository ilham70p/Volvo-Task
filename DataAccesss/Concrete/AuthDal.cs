using Core.DataAccess.Concrete;
using DataAccesss.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete
{
    public class AuthDal : Repository<User, AppDbContext>, IAuthDal
    {



        public User GetUserByMail(string mail)
        {
            using (AppDbContext context = new())
            {

                return context.Users.Where(a => a.Email == mail).FirstOrDefault();

            }
        }
    }
}
