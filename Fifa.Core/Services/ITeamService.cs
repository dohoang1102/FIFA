using System.Collections.Generic;

using Fifa.Core.Models;

namespace Fifa.Core.Services
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();

        Team CreateTeam();

        Team GetTeam(int id);

        void SaveTeam(Team user);

        void DeleteTeam(Team user);
    }
}