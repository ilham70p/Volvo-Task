using Core.Entity.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.Concrete
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R16MVQN;Database=VolvoDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Bus> Busses { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
