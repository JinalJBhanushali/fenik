using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string sortBy, bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return query;
            var propertyInfo = typeof(T).GetProperty(sortBy);
            if (propertyInfo == null)
                throw new ArgumentException($"Property '{sortBy}' does not exist on type '{typeof(T).Name}'.");
            return ascending
                ? query.OrderBy(e => propertyInfo.GetValue(e, null))
                : query.OrderByDescending(e => propertyInfo.GetValue(e, null));
        }
        public static IQueryable<T> ApplyIsDeletedFilter<T>(this IQueryable<T> query, bool isDeleted = false) where T : class
        {
            if (typeof(IHasIsDeleted).IsAssignableFrom(typeof(T))){
                query = query.Where(e => ((IHasIsDeleted)e).IsDeleted == isDeleted);
            }
            return query;
        }
    }
}
