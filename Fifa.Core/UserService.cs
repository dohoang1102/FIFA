using System;
using System.Collections.Generic;
using System.Linq;

using Fifa.Core.Models;
using Fifa.Core.Repositories.Filters;
using Fifa.Core.Repositories.Impl;

namespace Fifa.Core
{
    public class UserService
    {
        public static IEnumerable<User> GetAllUsers()
        {
            return Repository.Users.GetAllUsers();
        }

        public static User CreateUser()
        {
            return new User { RegistrationDate = DateTime.Now };
        }

        public static User GetUser(int id)
        {
            return Repository.Users.GetUser(id);
        }

        public static bool SaveTeam(User user)
        {
            Repository.Users.SaveUser(user);
            return true;
        }

        public static bool DeleteUser(User user)
        {
            Repository.Users.DeleteUser(user.Id);
            return true;
        }

        public static void CalculateStats(int userId)
        {
            var stats = Repository.UserStats.GetUserStats(userId);
            var games = Repository.Games.GetAllGames(new GameFilter { UserId = userId });
            stats.Games = games.Count;
            stats.Wins = games.Where(x =>
                    (x.PlayerAId == userId && x.ScoreA > x.ScoreB) || 
                    (x.PlayerBId == userId && x.ScoreA < x.ScoreB)).Count();
            stats.Ties = games.Where(x => x.ScoreA == x.ScoreB).Count();
            stats.Losses = stats.Games - stats.Wins - stats.Ties;
            if (stats.Games > 0)
            {
                stats.WinRate = stats.Wins * 1.00m / stats.Games * 100;
            }
            Repository.UserStats.SaveUserStats(stats);
        }
    }
}