using SalesInfoManager.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.SailsInfoManager.DAL.Abstractions
{
    public interface ISingleEntityUoW<Entity> : IDisposable where Entity : class
    {
        IGenericRepository<Entity> Repository { get; }
    }
}
