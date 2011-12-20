using System.Linq;

using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Services.Impl
{
    public class StatsService : IStatsService
    {
        private readonly IUserStatsRepository userStatsRepository;

        private readonly IGameRepository gameRepository;

        public StatsService(IUserStatsRepository userStatsRepository, IGameRepository gameRepository)
        {
            this.userStatsRepository = userStatsRepository;
            this.gameRepository = gameRepository;
        }

        public void CalculateStats(int userId)
        {
            var stats = userStatsRepository.GetUserStats(userId);
            var games = gameRepository.GetAllGames(new GameFilter { UserId = userId }).ToList();
            stats.Games = games.Count();
            stats.Wins = games.Where(x =>
                    (x.PlayerAId == userId && x.ScoreA > x.ScoreB) ||
                    (x.PlayerBId == userId && x.ScoreA < x.ScoreB)).Count();
            stats.Ties = games.Where(x => x.ScoreA == x.ScoreB).Count();
            stats.Losses = stats.Games - stats.Wins - stats.Ties;
            if (stats.Games > 0)
            {
                stats.WinRate = decimal.Round((stats.Wins * 1.0000m + stats.Ties * 0.5000m) / stats.Games * 100, 2);
            }
            userStatsRepository.SaveUserStats(stats);
        }
    }
}