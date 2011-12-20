using System.Data;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class Repository
    {
        public static IUserRepository Users { get; set; }
        public static IUserStatsRepository UserStats { get; set; }
        public static ICommentRepository Comments { get; set; }
        public static IGameRepository Games { get; set; }
        public static ITeamRepository Teams { get; set; }
        public static ITournamentRepository Tournaments { get; set; }

        static Repository()
        {
            Users = new UserRepository();
            UserStats = new UserStatsRepository();
            Comments = new CommentRepository();
            Games = new GameRepository();
            Teams = new TeamRepository();
            Tournaments = new TournamentRepository();
        }

        public static void UpdateEntity(MainContext context, BaseEntity entity)
        {
            context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
        }
    }
}