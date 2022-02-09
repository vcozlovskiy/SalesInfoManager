using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using SalesInfoManager.Persistence.Context;
using SalesInfoManager.DAL.Abstractions;

namespace SalesInfoManager.DAL.SailsInfoManagerContextFactories
{
    public class SalesInfoManegerContextFactory : ISalesInfoManagerContextFactory
    {
        private IConnectionFactory _connectionFactory;
        protected bool OpenOnCreate { get; set; } = false;

        public SalesInfoManegerContextFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public DbContext CreateInstance(DbConnection connection = null, bool contextOwnConnection = true)
        {
            var temp = (connection == null) ? _connectionFactory.CreateInstance(OpenOnCreate)
                : connection;
            if (temp == null) throw new InvalidOperationException("No connection object can be substituted");
            return new SalesInfoManagerDbContext(temp, contextOwnConnection);
        }

    }
}
