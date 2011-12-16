using System.Collections.Generic;

namespace Fifa.Core.Repositories
{
    public interface ITeamRepository
    {
        void DeleteTeam(int id);
        void SaveTeam(Team team);
        Team GetTeam(int id);
        IEnumerable<Team> GetAllTeams();
    }
}