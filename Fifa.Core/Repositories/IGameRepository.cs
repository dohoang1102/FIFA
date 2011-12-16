using System.Collections.Generic;

namespace Fifa.Core.Repositories
{
    public interface IGameRepository
    {
        void DeleteGame(int id);
        void SaveGame(Game game);
        Game GetGame(int id);
        IEnumerable<Game> GetAllGames();
    }
}