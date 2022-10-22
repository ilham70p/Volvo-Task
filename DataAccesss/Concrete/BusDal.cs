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
    public class BusDal:Repository<Bus,AppDbContext>,IBusDal
    {
    }
}
