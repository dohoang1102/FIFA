using Fifa.Core.Models;

namespace Fifa.Core.Services
{
    public interface IStatsService
    {
        void CalculateUser(int userId);
        void CalculateEloAll();
        void CalculateAll();
        UserStats GetUserStat(int userId);
    }
}
