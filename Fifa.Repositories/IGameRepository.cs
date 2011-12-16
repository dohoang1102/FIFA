using System.Collections.Generic;

using Fifa.Models;

namespace Fifa.Repositories
{
    public interface IGameRepository
    {
        void DeleteGame(int id);
        void SaveGame(Game game);
        Game GetGame(int id);
        IEnumerable<Game> LoadGames();
    }
}