using System;
using System.Collections.Generic;
using Fifa.Core.Models;
using Fifa.Core.Repositories;
using Fifa.Core.Repositories.Impl;

namespace Fifa.Core
{
    public class UserService
    {
        public static IEnumerable<User> GetAllUsers()
        {
            return Repository.Users.GetAllUsers();
        }

        public static User CreateUser()
        {
            return new User { RegistrationDate = DateTime.Now };
        }

        public static User GetUser(int id)
        {
            return Repository.Users.GetUser(id);
        }

        public static bool SaveTeam(User user)
        {
            Repository.Users.SaveUser(user);
            return true;
        }

        public static bool DeleteUser(User user)
        {
            Repository.Users.DeleteUser(user.Id);
            return true;
        }
    }
}