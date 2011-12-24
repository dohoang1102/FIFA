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

                playerA.Elo = (decimal)elo.RatingPlayerA;
                playerB.Elo = (decimal)elo.RatingPlayerB;
            }

            foreach(var stat in stats.Values)
            {
                userStatsRepository.SaveUserStats(stat);
            }
        }

        public void CalculateUser(int userId)
        {
            var stats = GetUserStat(userId);
            var games = gameRepository.GetAllGames(new GameFilter { UserId = userId }).ToList();
            stats.Games = games.Count();
            // TODO refactor this to RateCalculator (like EloCalculator)
            stats.Wins = games.Where(x =>
                    (x.PlayerAId == userId && x.ScoreA > x.ScoreB) ||
                    (x.PlayerBId == userId && x.ScoreA < x.ScoreB)).Count();
            stats.Draws = games.Where(x => x.ScoreA == x.ScoreB).Count();
            stats.Losses = stats.Games - stats.Wins - stats.Draws;
            if (stats.Games > 0)
            {
                stats.WinRate = 100 * (stats.Wins + stats.Draws * 0.5m) / stats.Games;
            }
            userStatsRepository.SaveUserStats(stats);
        }

        private UserStats getUserStat(Dictionary<int, UserStats> stats, int userId)
        {
            if (!stats.ContainsKey(userId))
            {
                var userStat = GetUserStat(userId);
                userStat.Elo = 0;
                stats.Add(userId, userStat);
            }
            return stats[userId];
        }

        public UserStats GetUserStat(int userId)
        {
            var user = _UserRepository.GetUser(userId);
            return userStatsRepository.GetUserStats(user.UserStatsId);
        }
    }
}