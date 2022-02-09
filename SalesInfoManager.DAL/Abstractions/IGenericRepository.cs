using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        DbContext Context { get; }
        T First(Expression<Func<T, bool>> filter);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);
        T Get(int id);
        IEnumerable<T> GetTList();
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        void Attach(T item);
        void Remove(T item);
        void Remove(IEnumerable<T> items);
        void Detach(T item);
        void Update(T item);
    }
}
