using System.Collections.Generic;
using Fifa.Core.Models;
using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Impl;

namespace Fifa.Core
{
    public class TeamService
    {
        public static IEnumerable<Team> GetAllTeams()
        {
            return Repository.Teams.GetAllTeams();
        }

        public static Team CreateTeam()
        {
            return new Team();
        }

        public static Team GetTeam(int id)
        {
            return Repository.Teams.GetTeam(id);
        }

        public static bool SaveTeam(Team user)
        {
            Repository.Teams.SaveTeam(user);
            return true;
        }

        public static bool DeleteTeam(Team user)
        {
            Repository.Teams.DeleteTeam(user.Id);
            return true;
        }
    }
}