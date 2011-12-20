using System.Collections.Generic;
using Fifa.Core.Models;
using Fifa.Core.Repositories.Filters;

namespace Fifa.Core.Repositories
{
    public interface IGameRepository
    {
        void DeleteGame(int id);
        void SaveGame(Game game);
        Game GetGame(int id);
        List<Game> GetAllGames(GameFilter filter);
    }
}