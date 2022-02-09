using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.DAL.Abstractions
{
    public interface IDataItemHandler<DTOEntity> : IDisposable
    {
        void SaveItem(DTOEntity dtoEntity);
    }
}
