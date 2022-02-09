using System.Data.Common;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IConnectionFactory
    {
        DbConnection CreateInstance(bool openOnCreate = false);
    }
}
