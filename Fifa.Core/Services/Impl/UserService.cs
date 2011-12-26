using System;
using System.Collections.Generic;

using Fifa.Core.Models;
using Fifa.Core.Repositories;

namespace Fifa.Core.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User CreateUser()
        {
            return new User { RegistrationDate = DateTime.Now };
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public void SaveUser(User user)
        {
            userRepository.SaveUser(user);
        }

        public void DeleteUser(User user)
        {
            userRepository.DeleteUser(user.Id);
        }
    }
}