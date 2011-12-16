using System.Collections.Generic;

using Fifa.Models;

namespace Fifa.Repositories
{
    public interface ITeamRepository
    {
        void DeleteTeam(int id);
        void SaveTeam(Team team);
        Team GetTeam(int id);
        IEnumerable<Team> GetAllTeams();
    }
}