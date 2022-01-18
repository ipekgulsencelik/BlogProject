using BlogProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccessLayer.Concrate.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();//contexte bağlı olarak gönderilen T değeri
        }

        public void Delete(T entity)
        {
            var deletedEntity = c.Entry(entity);
            deletedEntity.State = EntityState.Deleted;

            //  _object.Remove(entity);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T entity)
        {
            // _object.Add(entity);
            var addEntity = c.Entry(entity);
            addEntity.State = EntityState.Added;

            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            var updatedEntity = c.Entry(entity);
            updatedEntity.State = EntityState.Modified;

            c.SaveChanges();
        }
    }
}
