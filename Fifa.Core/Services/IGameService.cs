using System.Collections.Generic;

using Fifa.Core.Models;

namespace Fifa.Core.Services
{
    public interface IGameService1
    {
        IEnumerable<Game> GetAllGames();

        Game CreateGame();

        Game GetTeam(int id);

        void SaveGame(Game game);

        void DeleteGame(Game game);
    }
}