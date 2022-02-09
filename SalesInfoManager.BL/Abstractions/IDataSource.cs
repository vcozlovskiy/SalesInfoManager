using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SalesInfoManager.BL.Abstractions
{
    public interface IDataSource<DTOEntity> : IDisposable, IEnumerable<DTOEntity>
    {
        void Backup();
        Guid Id { get; }
    }
}
