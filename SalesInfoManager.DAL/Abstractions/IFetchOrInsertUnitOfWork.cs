using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.SailsInfoManager.DAL.Abstractions
{
    public interface IFetchOrInsertUnitOfWork<Entity> : ISingleEntityUoW<Entity> where Entity : class
    {
        Entity PerformAction(Expression<Func<Entity, bool>> filter, Entity forInsert);
    }
}
