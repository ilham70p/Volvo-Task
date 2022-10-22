using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IRepository<T> where T :class,new()
    {
        public List<T> GetAll();
        public T Get(int id);   
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
