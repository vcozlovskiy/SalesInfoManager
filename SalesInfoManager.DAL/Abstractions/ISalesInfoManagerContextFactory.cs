using System.Data.Common;
using System.Data.Entity;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface ISalesInfoManagerContextFactory
    {
        DbContext CreateInstance(DbConnection connection = null, bool contextOwnConnection = true);
    }
}
