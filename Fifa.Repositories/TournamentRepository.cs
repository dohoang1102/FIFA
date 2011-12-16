using System.Collections.Generic;
using System.Data;
using System.Linq;

using Fifa.Models;

namespace Fifa.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        public void DeleteTournament(int id)
        {
            var tournament = GetTournament(id);
            using (var context = new MainContext())
            {
                context.Entry(tournament).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveTournament(Tournament tournament)
        {
            using (var context = new MainContext())
            {
                Repository.UpdateEntity(context, tournament);
                context.SaveChanges();
            }
        }

        public Tournament GetTournament(int id)
        {
            using (var context = new MainContext())
            {
                return context.Tournaments.Find(id);
            }
        }

        public IEnumerable<Tournament> LoadTournaments()
        {
            using (var context = new MainContext())
            {
                return context.Tournaments.ToList();
            }
        }
    }
}
