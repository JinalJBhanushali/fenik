using Application.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CQS.Queries
{
    public interface IQueryContext : IEntityDbSet
    {
        IQueryable<T> Set<T>() where T : class;  // similar to DbContext.Set<T>() in Entity Framework
    }
}
