using System.Collections.Generic;

using Fifa.Models;
using Fifa.Repositories;

namespace Fifa.Core
{
    public class UserService
    {
        public IEnumerable<User> LoadUsers()
        {
            return Repository.Instance.LoadUsers();
        }
    }
}