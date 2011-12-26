using System.Collections.Generic;

using Fifa.Core.Models;

namespace Fifa.Core.Repositories
{
    public interface IUserStatsRepository
    {
        void DeleteUserStats(int id);
        void SaveUserStats(UserStats user);
        UserStats GetUserStats(int id);
        IEnumerable<UserStats> GetAllUserStats(int userId = 0);
        void RemoveAll();
        void SetLastStatsForUser();
    }
}
