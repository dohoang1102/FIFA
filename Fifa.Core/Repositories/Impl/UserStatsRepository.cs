using System.Collections.Generic;
using System.Data;
using System.Linq;

using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class UserStatsRepository : RepositoryBase, IUserStatsRepository
    {
        public void DeleteUserStats(int id)
        {
            var user = GetUserStats(id);
            using (var context = new MainContext())
            {
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveUserStats(UserStats user)
        {
            using (var context = new MainContext())
            {
                UpdateEntity(context, user);
                context.SaveChanges();
            }
        }

        public UserStats GetUserStats(int id)
        {
            using (var context = new MainContext())
            {
                return context.UserStats.Find(id);
            }
        }

        public IEnumerable<UserStats> GetAllUserStats()
        {
            using (var context = new MainContext())
            {
                return context.UserStats.ToList();
            }
        }
    }
}