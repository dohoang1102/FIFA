using System.Collections.Generic;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories
{
    public interface IUserRepository
    {
        void DeleteUser(int id);
        void SaveUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
    }
}