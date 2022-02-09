using SalesInfoManager.DAL.Abstractions;
using SalesInfoManager.DAL.UoWs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.DAL.UoWs
{
    public class AddEntityUoW<Entity> : BaseUoW<Entity>, IAddEntityUoW<Entity> where Entity : class
    {
        public IGenericRepository<Entity> Repository => base.Repository;

        public void AddEntity(Entity item)
        {
            Repository.Add(item);
            Repository.Context.SaveChanges();
        }

        public AddEntityUoW(IGenericRepository<Entity> repo) : base(repo)
        {
        }
    }
}
