using SalesInfoManager.BL.Abstractions;
using SalesInfoManager.DAL.Abstractions;
using SalesInfoManager.Persistence.Models;
using SalesInfoManager.SailsInfoManager.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.BL.DataHendler
{
    public class DataItemHandler<DTOEntity> : IDataItemHandler<DTOEntity> where DTOEntity : class
    {
        private bool isDisposed = false;

        private IDataSource<DTOEntity> dataSource;
        private IAddEntityUoW<DTOEntity> EntityUoW;

        public DataItemHandler(IAddEntityUoW<DTOEntity> addEntity)
        {
            this.EntityUoW = addEntity;
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed) return;

            if (isDisposing)
            {
                if (dataSource != null)
                {
                    dataSource.Dispose();
                    dataSource = null;
                }

                if (EntityUoW != null)
                {
                    EntityUoW.Dispose();
                    EntityUoW = null;
                }
            }
            isDisposed = true;

        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataItemHandler()
        {
            Dispose(false);
        }

        public void SaveItem(DTOEntity item)
        {
            EntityUoW.AddEntity(item);
        }
    }
}
