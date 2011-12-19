using System.Collections.Generic;
using System.Data;
using System.Linq;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class GameRepository : IGameRepository
    {
        public void DeleteGame(int id)
        {
            var game = GetGame(id);
            using (var context = new MainContext())
            {
                context.Entry(game).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveGame(Game game)
        {
            using (var context = new MainContext())
            {
                Repository.UpdateEntity(context, game);
                context.SaveChanges();
            }
        }

        public Game GetGame(int id)
        {
            using (var context = new MainContext())
            {
                return context.Games.Find(id);
            }
        }

        public IEnumerable<Game> GetAllGames()
        {
            using (var context = new MainContext())
            {
                return context.Games.Include("PlayerA").Include("PlayerB").Include("TeamA").Include("TeamB").
                        OrderByDescending(x => x.Date).ToList();
            }
        }
    }
}