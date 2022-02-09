using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Text;
using System.Threading.Tasks;
using SalesInfoManager.DAL.Abstractions;
using SalesInfoManager.DAL.UoWs;
using SalesInfoManager.Persistence.Models;

namespace SalesInfoManager.DAL.UoWs
{
    public class GetEntityUoW<Entity> : BaseUoW<Entity>, IGetEntity<Entity> where Entity : class
    {
        protected Logger _logger;
        public IGenericRepository<Entity> Repository => base.Repository;
        public Entity GetEntity(int id)
        {
            return base.Repository.Get(id);
        }
        public Client GetClient(string name)
        {
            Client client; 
            try
            {
                client = base.Repository.Context.Set<Client>().Where(x => x.FullName == name).First();
            }
            catch(InvalidOperationException e)
            {
                _logger.Info($"Client not found. Create new Client {name}");
                client = new Client(name);
                base.Repository.Context.Set<Client>().Add(client);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                client = null;
            }

            return  client;
        }
        public Item GetItem(string itemName)
        {
            Item item;
            try
            {
                item = base.Repository.Context.Set<Item>().Where(x => x.Name == itemName).First();
            }
            catch (InvalidOperationException e)
            {
                _logger.Info($"Item not found. Create new Item {itemName}");
                item = new Item(itemName);
                base.Repository.Context.Set<Item>().Add(item);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                item = null;
            }

            return item;
        }

        public Manager GetManager(string managerName)
        {
            Manager item;

            try
            {
                item = base.Repository.Context.Set<Manager>().Where(x => x.FullName == managerName).First();
            }
            catch (InvalidOperationException e)
            {
                _logger.Info($"Manager not found. Create new Manager {managerName}");
                item = new Manager(managerName);
                base.Repository.Context.Set<Manager>().Add(item);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                item = null;
            }

            return item;

        }

        public GetEntityUoW(IGenericRepository<Entity> repo) : base(repo)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
    }
}
