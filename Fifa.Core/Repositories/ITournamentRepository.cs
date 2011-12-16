using System.Collections.Generic;

namespace Fifa.Core.Repositories
{
    public interface ITournamentRepository
    {
        void DeleteTournament(int id);
        void SaveTournament(Tournament tournament);
        Tournament GetTournament(int id);
        IEnumerable<Tournament> GetAllTournaments();
    }
}
