using System.Collections.Generic;

using Fifa.Models;

namespace Fifa.Repositories
{
    public interface IUserRepository
    {
        void DeleteUser(int id);
        void SaveUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
    }
}