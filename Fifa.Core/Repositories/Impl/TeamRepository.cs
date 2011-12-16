using System.Collections.Generic;
using System.Linq;

namespace Fifa.Core.Repositories.Impl
{
    public class TeamRepository : ITeamRepository
    {
        public void DeleteTeam(int id)
        {
            var team = GetTeam(id);
            using (var context = new MainContext())
            {
                context.Entry(team).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveTeam(Team team)
        {
            using (var context = new MainContext())
            {
                Repository.UpdateEntity(context, team);
                context.SaveChanges();
            }
        }

        public Team GetTeam(int id)
        {
            using (var context = new MainContext())
            {
                return context.Teams.Find(id);
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (var context = new MainContext())
            {
                return Enumerable.ToList(context.Teams);
            }
        }
    }
}
