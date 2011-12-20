using System.Data;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public abstract class RepositoryBase
    {
        protected void UpdateEntity(MainContext context, BaseEntity entity)
        {
            context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
        }
    }
}