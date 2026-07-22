using Application.Common.CQS.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccessManager.EFCore.Contexts
{
    public class QueryContext : DataContext, IQueryContext
    {
        public QueryContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public new IQueryable<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }

}
