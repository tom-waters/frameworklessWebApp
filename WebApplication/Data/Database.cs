using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Domain;

namespace WebApplication.Data
{
    public class Database : IDatabase
    {
        private const string PowerUser = "Tom";
        private List<User> _allUsers = new List<User>();

        public Database()
        {
            _allUsers.Add(new User(PowerUser));
        }

        public List<User> GetUsers()
        {
            return _allUsers;
        }
        
        public void AddUser(User user)
        {
            _allUsers.Add(user);
        }

        public void UpdateUser(User user, string newName)
        {
            _allUsers.First(entry => entry == user).Name = newName;
        }

        public void DeleteUser(User user)
        {
            _allUsers.Remove(user);
        }
    }
}