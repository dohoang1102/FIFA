using System;
using System.Collections.Generic;
using System.Linq;

namespace Fifa.Core.Repositories.Impl
{
    public static class EntityFrameworkExtension
    {
        public static IEnumerable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
            {
                return source.Where(predicate);
            }
            return source;
        }
    }
}