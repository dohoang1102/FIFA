using System.Collections.Generic;

using Fifa.Models;

namespace Fifa.Repositories
{
    public interface ITournamentRepository
    {
        void DeleteTournament(int id);
        void SaveTournament(Tournament tournament);
        Tournament GetTournament(int id);
        IEnumerable<Tournament> GetAllTournaments();
    }
}
