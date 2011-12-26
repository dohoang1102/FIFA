using System.Collections.Generic;

using Fifa.Core.Models;

namespace Fifa.Core.Services
{
    public interface IHistoryService
    {
        List<UserStats> GetUserHistory(int userId);
    }
}