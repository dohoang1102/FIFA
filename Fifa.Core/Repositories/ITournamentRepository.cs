using System.Collections.Generic;
using Fifa.Core.Models;

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
