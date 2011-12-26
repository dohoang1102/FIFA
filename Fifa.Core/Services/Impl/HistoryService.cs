using System.Collections.Generic;
using System.Linq;
using Fifa.Core.Models;
using Fifa.Core.Repositories;

namespace Fifa.Core.Services.Impl
{
    public class HistoryService : IHistoryService
    {
        private readonly IUserStatsRepository _UserStatsRepository;

        public HistoryService(IUserStatsRepository userStatsRepository)
        {
            _UserStatsRepository = userStatsRepository;
        }

        public List<UserStats> GetUserHistory(int userId)
        {
            var stats = _UserStatsRepository.GetAllUserStats(userId).OrderByDescending(x => x.CalcDate).ToList();
            return stats;
        }
    }
}