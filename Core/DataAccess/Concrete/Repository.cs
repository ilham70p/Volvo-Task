using Core.DataAccess.Abstract;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {



        public List<TEntity> GetAll()
        {

            using TContext context = new TContext();
            var getget = context.Set<TEntity>().ToList();
            return getget;
        }

        public TEntity Get(int Id)
        {
            using TContext context = new TContext();
            var mymodel = context.Set<TEntity>().Find(Id);
            return mymodel;
        }


        public void Add(TEntity model)
        {
            using TContext context = new TContext();
            var getget = context.Set<TEntity>().Add(model);
            context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }





        public void Update(TEntity entity)
        {
            using TContext context = new TContext();
            var getget = context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
