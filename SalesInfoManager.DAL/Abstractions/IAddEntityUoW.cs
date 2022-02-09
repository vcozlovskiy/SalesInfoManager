using SalesInfoManager.SailsInfoManager.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IAddEntityUoW<Entity> : ISingleEntityUoW<Entity> where Entity : class
    {
        void AddEntity(Entity item);
    }
}
