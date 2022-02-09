using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SalesInfoManager.DAL.Abstractions;

namespace SalesInfoManager.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        DbContext IGenericRepository<T>.Context => Context;

        protected DbContext Context;

        private bool isDisposed = false;

        public GenericRepository(DbContext dbContext)
        {
            Context = dbContext;
        }
        ~GenericRepository()
        {
            Dispose(false);
        }

        public virtual void Add(T item)
        {
            Context.Set<T>().Add(item);
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public virtual void Attach(T item)
        {
            Context.Set<T>().Attach(item);
        }

        public virtual void Detach(T item)
        {
            Context.Entry(item).State = EntityState.Detached;
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed) return;
            if (isDisposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
            isDisposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual T First(Expression<Func<T, bool>> filter)
        {
            return filter != null ? Context.Set<T>().FirstOrDefault(filter) : Context.Set<T>().FirstOrDefault();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? Context.Set<T>().Where(filter) : Context.Set<T>();
        }
        public virtual IEnumerable<T> GetTList()
        {
            return Context.Set<T>();
        }

        public virtual T Get(int id)
        {
            T obj = Context.Set<T>().Find(id);

            return obj != null ? obj : throw new InvalidOperationException();
        }

        public virtual void Remove(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public virtual void Remove(IEnumerable<T> items)
        {
            Context.Set<T>().RemoveRange(items);
        }

        public virtual void Update(T item)
        {
            var entry = Context.Entry<T>(item);
            if (entry.State == EntityState.Detached)
            {
                Attach(item);
            }
            entry.State = EntityState.Modified;
        }
    }
}
