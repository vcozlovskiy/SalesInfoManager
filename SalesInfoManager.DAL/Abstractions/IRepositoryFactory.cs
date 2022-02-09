using System.Data.Entity;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IRepositoryFactory
    {
        IGenericRepository<Entity> CreateInstance<Entity>(DbContext context) where Entity : class;
    }
}
