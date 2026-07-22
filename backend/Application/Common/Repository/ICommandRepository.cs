using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repository
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Purge(T entity);

        Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);

        T? Get(int id);

        IQueryable<T> GetQuery();
    }


}
