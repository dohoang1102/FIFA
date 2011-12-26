using System.Collections.Generic;
using System.Data;
using System.Linq;
using Fifa.Core.Models;

namespace Fifa.Core.Repositories.Impl
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            using (var context = new MainContext())
            {
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SaveUser(User user)
        {
            using (var context = new MainContext())
            {
                UpdateEntity(context, user);
                context.SaveChanges();
            }
        }

        public User GetUser(int id)
        {
            using (var context = new MainContext())
            {
                return context.Users.Find(id);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var context = new MainContext())
            {
                //извините за эту тупость. кто может - решите.
                var users = context.Users.Include("UserStats").ToList();
                var list = users.OrderByDescending(x => x.LastUserStats.Elo).ToList();
                return list;
            }
        }
    }
}