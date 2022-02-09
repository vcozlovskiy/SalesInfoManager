using SalesInfoManager.BL.Abstractions;
using SalesInfoManager.DAL.Abstractions;
using SalesInfoManager.Persistence.Models;
using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using SalesInfoManager.Persistence.Context;
using System.Threading.Tasks;
using SalesInfoManager.BL.DataHendler;
using SalesInfoManager.DAL.UoWs;
using SalesInfoManager.DAL.Repositories;
using System.Data.Entity.Validation;

namespace SailsInfoManager.SalesInfoManager.BL.DataWorker
{
    public class DataPreDayWorker : IDataWorker<Client>
    {
        private IGenericRepository<Client> clientRepository;
        private IGenericRepository<Order> orderRepository;

        private IAddEntityUoW<Client> addClient;
        private IGetEntity<Client> getClient;

        IDataSource<SalesDataSourceDTO> sourceDTOs;
        ILogger logger;
        public DataPreDayWorker(SalesInfoManagerDbContext salesInfoManager, IDataSource<SalesDataSourceDTO> sales)
        {
            clientRepository = new GenericRepository<Client>(salesInfoManager);
            addClient = new AddEntityUoW<Client>(clientRepository);

            orderRepository = new GenericRepository<Order>(salesInfoManager);

            getClient = new GetEntityUoW<Client>(clientRepository);
            sourceDTOs = sales;

            logger = LogManager.GetCurrentClassLogger();
        }
        public void ProcessData()
        {
            foreach (SalesDataSourceDTO sourceDTO in sourceDTOs)
            {
                var tempClient = getClient.GetClient(sourceDTO.ClientName);
                var tempManager = getClient.GetManager(sourceDTO.ManagerLastName);

                Order tempOrder = new Order()
                {
                    dateTimeOrder = sourceDTO.DataTimeOrder,
                    Item = getClient.GetItem(sourceDTO.ItemName),
                    Price = sourceDTO.Price,
                };

                tempManager.Orders.Add(tempOrder);
                tempClient.Orders.Add(tempOrder);
            }
            try
            {
                orderRepository.Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString()); 
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(err.ErrorMessage);
                    }
                }
            }

            logger.Info("Order saved");

            sourceDTOs.Backup();
        }
    }
}
