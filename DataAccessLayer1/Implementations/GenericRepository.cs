using DataAccessLayer.Abstractions;
using DataAccessLayer.Contrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity)
        {
            using (Context db = new Context())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (Context db = new Context())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (Context db = new Context())
            {
                var values = db.Set<T>().ToList();
                return values;
            }
        }

        public T GetById(int id)
        {
            using (Context db = new Context())
            {
                var value = db.Set<T>().Find(id);
                return value;
            }
        }

        public void Update(T entity)
        {
            using (Context db = new Context())
            {
                db.Update(entity);
                db.SaveChanges();
            }
        }
    }
}
