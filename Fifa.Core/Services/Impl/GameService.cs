using System;
using System.Collections.Generic;

using Fifa.Core.Models;
using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Services.Impl
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        private readonly IStatsService statsService;

        public GameService(IGameRepository gameRepository, IStatsService statsService)
        {
            this.gameRepository = gameRepository;
            this.statsService = statsService;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return gameRepository.GetAllGames(new GameFilter());
        }

        public Game CreateGame()
        {
            return new Game { Date = DateTime.Now };
        }

        public Game GetTeam(int id)
        {
            return gameRepository.GetGame(id);
        }

        public void SaveGame(Game game)
        {
            gameRepository.SaveGame(game);

            statsService.CalculateStats(game.PlayerAId);
            statsService.CalculateStats(game.PlayerBId);
        }

        public void DeleteGame(Game game)
        {
            gameRepository.DeleteGame(game.Id);
        }
    }
}