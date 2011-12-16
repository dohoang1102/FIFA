using System.Collections.Generic;
using System.Linq;

using Fifa.Models;
using System.Data;

namespace Fifa.Repositories
{
    public class UserRepository : IUserRepository
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
                Repository.UpdateEntity(context, user);
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
                return context.Users.ToList();
            }
        }
    }
}