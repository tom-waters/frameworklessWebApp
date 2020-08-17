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
        
        public Tuple<bool, string> AddUser(User user)
        {
            var matchingEntries = _allUsers.Any(entry => entry.Name == user.Name);
            if (!matchingEntries)
            {
                _allUsers.Add(user);
                return new Tuple<bool, string>(true, "User added");
            }
            return new Tuple<bool, string>(false, "User already exists");
        }

        public Tuple<bool, string> UpdateUser(User user, string newName)
        {
            if (_allUsers.Contains(user))
            {
                _allUsers.First(entry => entry == user).Name = newName;
                return new Tuple<bool, string>(true, "User updates");
            }
            return new Tuple<bool, string>(false, "User doesn't exist");
        }

        public Tuple<bool, string> DeleteUser(User user)
        {
            if (user.Name != PowerUser && _allUsers.Contains(user))
            {
                _allUsers.Remove(user);
                return new Tuple<bool, string>(true, "User deleted");
            }
            return new Tuple<bool, string>(false, "User doesn't exist");
        }
    }
}