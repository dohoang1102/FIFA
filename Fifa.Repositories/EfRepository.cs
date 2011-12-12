using System.Collections.Generic;
using System.Linq;

using Fifa.Models;
using System.Data;

namespace Fifa.Repositories
{
    public class EfRepository : IRepository
    {
        #region Comments

        public void DeleteComment(int id)
        {
            var comment = GetComment(id);
            using (var context = new MainContext())
            {
                context.Entry(comment).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveComment(Comment comment)
        {
            using (var context = new MainContext())
            {
                updateEntity(context, comment);
                context.SaveChanges();
            }
        }

        public Comment GetComment(int id)
        {
            using (var context = new MainContext())
            {
                return context.Comments.Find(id);
            }
        }

        public IEnumerable<Comment> LoadComments()
        {
            using (var context = new MainContext())
            {
                return context.Comments.ToList();
            }
        }

        #endregion

        #region Games

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
                updateEntity(context, game);
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

        public IEnumerable<Game> LoadGames()
        {
            using (var context = new MainContext())
            {
                return context.Games.ToList();
            }
        }

        #endregion

        #region Teams

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
                updateEntity(context, team);
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

        public IEnumerable<Team> LoadTeams()
        {
            using (var context = new MainContext())
            {
                return context.Teams.ToList();
            }
        }

        #endregion

        #region Tournaments

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
                updateEntity(context, tournament);
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

        #endregion

        #region Users

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            using (var context = new MainContext())
            {
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveUser(User user)
        {
            using (var context = new MainContext())
            {
                updateEntity(context, user);
                context.SaveChanges();
            }
        }

        public User GetUser(int id)
        {
            using (var context = new MainContext())
            {
                return context.Users.Find(id);
            }
        }

        public IEnumerable<User> LoadUsers()
        {
            using (var context = new MainContext())
            {
                return context.Users.ToList();
            }
        }

        #endregion

        private static void updateEntity(MainContext context, BaseEntity entity)
        {
            context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
        }
    }
}