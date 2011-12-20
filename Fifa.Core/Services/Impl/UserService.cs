using System;
using System.Collections.Generic;
using System.Linq;

using Fifa.Core.Models;
using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IUserStatsRepository userStatsRepository;

        private readonly IGameRepository gameRepository;

        public UserService(IUserRepository userRepository, IUserStatsRepository userStatsRepository, IGameRepository gameRepository)
        {
            this.userRepository = userRepository;
            this.userStatsRepository = userStatsRepository;
            this.gameRepository = gameRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User CreateUser()
        {
            return new User { RegistrationDate = DateTime.Now };
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public void SaveTeam(User user)
        {
            userRepository.SaveUser(user);
        }

        public void DeleteUser(User user)
        {
            userRepository.DeleteUser(user.Id);
        }

        public void CalculateStats(int userId)
        {
            var stats = userStatsRepository.GetUserStats(userId);
            var games = gameRepository.GetAllGames(new GameFilter { UserId = userId });
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