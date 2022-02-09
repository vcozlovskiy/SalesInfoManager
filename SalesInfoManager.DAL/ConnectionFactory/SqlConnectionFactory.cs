using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesInfoManager.DAL.Abstractions;

namespace SalesInfoManager.BL.ConnectionFactory
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionStr;
        public DbConnection CreateInstance(bool openOnCreate = false)
        {
            var temp = new SqlConnection(_connectionStr);
            if (openOnCreate) temp.Open();
            return temp;
        }

        public SqlConnectionFactory(string connectionString)
        {
            _connectionStr = connectionString;
        }
    }
}
