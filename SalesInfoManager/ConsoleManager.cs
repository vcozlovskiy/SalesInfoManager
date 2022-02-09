using System;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using SalesInfoManager.Persistence.Context;
using SalesInfoManager.Persistence.Models;
using SalesInfoManager.BL.ConnectionFactory;
using SalesInfoManager.DAL.Repositories;
using SalesInfoManager.BL.SailsDataSources;
using NLog;
using SalesInfoManager.DAL.UoWs;
using SailsInfoManager.SalesInfoManager.BL.DataWorker;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace SailsInfoManager.SalesInfoManager
{
    public class ConsoleManager
    {
        private Settings _settings;
        private ILogger _logger;
        public ConsoleManager(ILogger logger, Settings settings = null)
        {
            _logger = logger;
            _settings = new Settings();
            _logger.Info("Console application start");
        }
        public void StartApp()
        {
            SqlConnectionFactory connection = new SqlConnectionFactory(_settings.connectionString);

            GenericRepository<Client> clientRepository = new GenericRepository<Client>(new SalesInfoManagerDbContext(connection.CreateInstance(), true));

            GetEntityUoW<Client> getEntityUo = new GetEntityUoW<Client>(clientRepository);
            getEntityUo.Repository.Context.SaveChanges();

            string[] files = Directory.GetFiles(_settings.soursePath);
            Regex regex = new Regex(@"\w*_\d*");

            List<string> filesList = new List<string>();

            if (files.Length == 0)
            {
                _logger.Info("Files not found");
            }
            foreach (var file in files)
            {
                Match matchCollection = regex.Match(file);
                if (matchCollection.Length != 0)
                {
                    filesList.Add(matchCollection.Value);
                }
            }

            foreach (var fileName in filesList)
            {
                DataPreDayWorker worker = new DataPreDayWorker(new SalesInfoManagerDbContext(
                    connection.CreateInstance(), false),new SalesDataSource($"{_settings.soursePath}{fileName}.csv", _settings.targetPath));
                worker.ProcessData();
            }
        }
    }
}
