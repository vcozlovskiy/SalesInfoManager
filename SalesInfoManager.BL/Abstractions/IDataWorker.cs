using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.BL.Abstractions
{
    public interface IDataWorker<Entity> where Entity : class
    {
        void ProcessData();
    }
}
