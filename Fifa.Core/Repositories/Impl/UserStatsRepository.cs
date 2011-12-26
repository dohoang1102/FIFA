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

        public IEnumerable<UserStats> GetAllUserStats(int userId=0)
        {
            using (var context = new MainContext())
            {
                return context.UserStats.
                    Include("Game").
                    Include("Game.PlayerA").
                    Include("Game.PlayerB").
                    Include("Game.TeamA").
                    Include("Game.TeamB").
                    WhereIf(userId > 0, x => x.UserId == userId).
                    ToList();
            }
        }

        public void RemoveAll()
        {
            using (var context = new MainContext())
            {
                //context.Database.ExecuteSqlCommand("UPDATE dbo.Users SET UserStatsId = NULL");

                foreach (var stat in context.UserStats.ToList())
                {
                    context.Entry(stat).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }

        public void SetLastStatsForUser()
        {
//            using (var context = new MainContext())
//            {
//                context.Database.ExecuteSqlCommand(@"
//UPDATE	x
//	SET	x.UserStatsId=(	SELECT TOP 1 s.Id
//						FROM dbo.UserStats s
//						WHERE s.UserId = x.Id
//						ORDER BY s.CalcDate DESC)
//FROM	dbo.Users x)");
//            }
        }
    }
}