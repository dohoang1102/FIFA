using System;
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
        private readonly IUserStatsRepository _UserStatsRepository;

        private readonly IGameRepository gameRepository;

        public StatsService(IUserStatsRepository userStatsRepository, IGameRepository gameRepository)
        {
            _UserStatsRepository = userStatsRepository;
            this.gameRepository = gameRepository;
        }

        public void CalculateAll()
        {
            _UserStatsRepository.RemoveAll();

            var games = gameRepository.GetAllGames(new GameFilter()).ToList().OrderBy(x => x.Date);
            var stats = new List<UserStats>();

            foreach (var game in games)
            {
                UserStats playerA = cloneNewUserStats(stats, game.PlayerAId, game);
                UserStats playerB = cloneNewUserStats(stats, game.PlayerBId, game);

                calculateGame(game, playerA, playerB);

                stats.Add(playerA);
                stats.Add(playerB);
            }

            foreach (var stat in stats)
            {
                _UserStatsRepository.SaveUserStats(stat);
            }
            _UserStatsRepository.SetLastStatsForUser();
        }

        public void CalculateEloAll()
        {
            throw new NotImplementedException();
            //    var games = gameRepository.GetAllGames(new GameFilter()).ToList().OrderBy(x => x.Date);
            //    var stats = new Dictionary<int, UserStats>();

            //    foreach(var game in games)
            //    {
            //        UserStats playerA = getUserStat(stats, game.PlayerAId);
            //        UserStats playerB = getUserStat(stats, game.PlayerBId);

            //        var elo = new EloCalculator(playerA.Elo, playerB.Elo);
            //        if (game.ScoreA > game.ScoreB)
            //        {
            //            elo.WinGamePlayerA();
            //        }
            //        else if (game.ScoreA < game.ScoreB)
            //        {
            //            elo.WinGamePlayerB();
            //        }
            //        else
            //        {
            //            elo.DrawGame();
            //        }

            //        playerA.Elo = (decimal)elo.RatingPlayerA;
            //        playerB.Elo = (decimal)elo.RatingPlayerB;
            //    }

            //    foreach(var stat in stats.Values)
            //    {
            //        userStatsRepository.SaveUserStats(stat);
            //    }
        }

        public void CalculateUser(int userId)
        {
            throw new NotImplementedException();
        //    var stats = getUserStat(userId);
        //    var games = gameRepository.GetAllGames(new GameFilter { UserId = userId }).ToList();
        //    stats.Games = games.Count();
        //    stats.Wins = games.Where(x =>
        //            (x.PlayerAId == userId && x.ScoreA > x.ScoreB) ||
        //            (x.PlayerBId == userId && x.ScoreA < x.ScoreB)).Count();
        //    stats.Draws = games.Where(x => x.ScoreA == x.ScoreB).Count();
        //    stats.Losses = stats.Games - stats.Wins - stats.Draws;
        //    if (stats.Games > 0)
        //    {
        //        stats.WinRate = decimal.Round((stats.Wins * 1.0000m + stats.Draws * 0.5000m) / stats.Games * 100, 2);
        //    }
        //    _UserStatsRepository.SaveUserStats(stats);
        }

        private UserStats cloneNewUserStats(IEnumerable<UserStats> stats, int userId, Game game)
        {
            var stat = stats.Where(x => x.UserId == userId).OrderByDescending(x => x.CalcDate).FirstOrDefault();
            if (stat == null)
            {
                stat = new UserStats { UserId = userId };
            }
            else
            {
                stat = new UserStats
                    {
                        UserId = userId,
                        Draws = stat.Draws,
                        Elo = stat.Elo,
                        Losses = stat.Losses,
                        WinRate = stat.WinRate,
                        Wins = stat.Wins,
                        Games=stat.Games
                    };
            }
            stat.CalcDate = game.Date;
            stat.GameId = game.Id;
            return stat;
        }

        private void calculateGame(Game game, UserStats statsA, UserStats statsB)
        {
            calculateElo(game, statsA, statsB);
            calculateGeneralStats(game, statsA, statsB);
        }

        private void calculateElo(Game game, UserStats statsA, UserStats statsB)
        {
            var elo = new EloCalculator(statsA.Elo, statsB.Elo);
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

            statsA.Elo = (decimal)elo.RatingPlayerA;
            statsB.Elo = (decimal)elo.RatingPlayerB;
        }

        private void calculateGeneralStats(Game game, UserStats statsA, UserStats statsB)
        {
            calculateGeneralStatsForPlayer(game, statsA);
            calculateGeneralStatsForPlayer(game, statsB);
        }

        private void calculateGeneralStatsForPlayer(Game game, UserStats stats)
        {
            stats.Games++;
            if (game.ScoreA == game.ScoreB)
            {
                stats.Draws++;
            }
            else
            {
                if (game.PlayerAId == stats.UserId)
                {
                    if (game.ScoreA > game.ScoreB)
                    {
                        stats.Wins++;
                    }
                    else
                    {
                        stats.Losses++;
                    }
                }
                else
                {
                    if (game.ScoreB > game.ScoreA)
                    {
                        stats.Wins++;
                    }
                    else
                    {
                        stats.Losses++;
                    }
                }
            }
            stats.WinRate = decimal.Round((stats.Wins * 1.0000m + stats.Draws * 0.5000m) / stats.Games * 100, 2);
        }

        //private UserStats getUserStat(Dictionary<int, UserStats> stats, int userId)
        //{
        //    if (!stats.ContainsKey(userId))
        //    {
        //        stats.Add(userId, new UserStats { UserId = userId });
        //    }
        //    return stats[userId];
        //}

        //private UserStats getUserStat(Dictionary<int, UserStats> stats, int userId)
        //{
        //    if (!stats.ContainsKey(userId))
        //    {
        //        var userStat = getUserStat(userId);
        //        userStat.Elo = 0;
        //        stats.Add(userId, userStat);
        //    }
        //    return stats[userId];
        //}

        //private UserStats getUserStat(int userId)
        //{
        //    var user = _UserRepository.GetUser(userId);
        //    if (user.UserStatsId == null) return new UserStats();
        //    return userStatsRepository.GetUserStats(user.UserStatsId.Value);
        //}
    }
}