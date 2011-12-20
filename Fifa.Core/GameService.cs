using System;
using System.Collections.Generic;
using Fifa.Core.Models;
using Fifa.Core.Repositories.Filters;
using Fifa.Core.Repositories.Impl;

namespace Fifa.Core
{
    public class GameService
    {
        public static IEnumerable<Game> GetAllGames()
        {
            return Repository.Games.GetAllGames(new GameFilter());
        }

        public static Game CreateGame()
        {
            return new Game { Date = DateTime.Now };
        }

        public static Game GetTeam(int id)
        {
            return Repository.Games.GetGame(id);
        }

        public static bool SaveGame(Game game)
        {
            Repository.Games.SaveGame(game);

            UserService.CalculateStats(game.PlayerAId);
            UserService.CalculateStats(game.PlayerBId);

            return true;
        }

        public static bool DeleteGame(Game game)
        {
            Repository.Games.DeleteGame(game.Id);
            return true;
        }
    }
}