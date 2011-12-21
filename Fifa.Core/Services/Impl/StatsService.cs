using System.Collections.Generic;
using System.Linq;

using Fifa.Core.Helpers;
using Fifa.Core.Models;
using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Services.Impl
{
    public class StatsService : IStatsService
    {
        private readonly IUserStatsRepository userStatsRepository;

        private readonly IGameRepository gameRepository;
        private readonly IUserRepository _UserRepository;

        public StatsService(IUserStatsRepository userStatsRepository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.userStatsRepository = userStatsRepository;
            this.gameRepository = gameRepository;
            _UserRepository = userRepository;
        }

        public void CalculateEloAll()
        {
            var games = gameRepository.GetAllGames(new GameFilter()).ToList().OrderBy(x => x.Date);
            var stats = new Dictionary<int, UserStats>();

            foreach(var game in games)
            {
                UserStats playerA = getUserStat(stats, game.PlayerAId);
                UserStats playerB = getUserStat(stats, game.PlayerBId);

                var elo = new EloCalculator(playerA.Elo, playerB.Elo);
                if (game.ScoreA > game.ScoreB)
                {
                    elo.WinGamePlayerA();
                }
                else if (game.ScoreA < game.ScoreB)
                {
                    elo.WinGamePlayerB();
                }
                else
                {
                    elo.DrawGame();
                }

                playerA.Elo = elo.RatingPlayerA;
                playerB.Elo = elo.RatingPlayerB;
            }

            foreach(var stat in stats.Values)
            {
                userStatsRepository.SaveUserStats(stat);
            }
        }

        public void CalculateUser(int userId)
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

        private UserStats getUserStat(Dictionary<int, UserStats> stats, int userId)
        {
            if (!stats.ContainsKey(userId))
            {
                var user = _UserRepository.GetUser(userId);
                stats.Add(userId, userStatsRepository.GetUserStats(user.UserStatsId));
            }
            return stats[userId];
        }
    }
}