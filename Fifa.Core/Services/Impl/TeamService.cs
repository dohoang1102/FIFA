using System.Collections.Generic;

using Fifa.Core.Models;
using Fifa.Core.Repositories;

namespace Fifa.Core.Services.Impl
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return teamRepository.GetAllTeams();
        }

        public Team CreateTeam()
        {
            return new Team();
        }

        public Team GetTeam(int id)
        {
            return teamRepository.GetTeam(id);
        }

        public void SaveTeam(Team user)
        {
            teamRepository.SaveTeam(user);
        }

        public void DeleteTeam(Team user)
        {
            teamRepository.DeleteTeam(user.Id);
        }
    }
}