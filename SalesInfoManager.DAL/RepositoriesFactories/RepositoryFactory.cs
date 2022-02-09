using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesInfoManager.DAL.Abstractions;
using SalesInfoManager.DAL.Repositories;

namespace SalesInfoManager.DAL.RepositoriesFactories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IGenericRepository<Entity> CreateInstance<Entity>(DbContext context) where Entity : class
        {
            return new GenericRepository<Entity>(context);
        }
    }
}
