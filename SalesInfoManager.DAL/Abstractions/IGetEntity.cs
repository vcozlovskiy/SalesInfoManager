using SalesInfoManager.Persistence.Models;
using SalesInfoManager.SailsInfoManager.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IGetEntity<Entity> : ISingleEntityUoW<Entity> where Entity : class
    {
        Entity GetEntity(int id);
        Client GetClient(string name);
        Item GetItem(string itemName);
        Manager GetManager(string manegerName);
    }
}
