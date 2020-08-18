using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using WebApplication.Domain;

namespace WebApplication.Data
{
    public class Database : IDatabase
    {
        private const string PowerUser = "tom";
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
            if (!HasMatchingUser(user))
            {
                _allUsers.Add(user);
                return new Tuple<bool, string>(true, "User added");
            }
            return new Tuple<bool, string>(false, "User already exists");
        }

        public Tuple<bool, string> UpdateUser(User user, string newName)
        {
            if (IsPowerUser(user))
            {
                return new Tuple<bool, string>(false, "Poweruser cannot be modified");
            }
            if (!HasMatchingUser(user))
            {
                return new Tuple<bool, string>(false, "User doesn't exist");
            }
            var userToUpdate = FindMatchingUser(user).Name = newName;
            return new Tuple<bool, string>(true, "User updated");
        }

        public Tuple<bool, string> DeleteUser(User user)
        {
            if (IsPowerUser(user))
            {
                return new Tuple<bool, string>(false, "Cannot removed Poweruser");
            }
            if (!HasMatchingUser(user))
            {
                return new Tuple<bool, string>(false, "User doesn't exist");
            }
            _allUsers.Remove(FindMatchingUser(user));
            return new Tuple<bool, string>(true, "User deleted");
        }

        private User FindMatchingUser(User user)
        {
            return _allUsers.FirstOrDefault(entry => entry.Name == user.Name);
        }

        private bool HasMatchingUser(User user)
        {
            return _allUsers.Any(entry => entry.Name == user.Name);
        } 
        private bool IsPowerUser(User user)
        {
            return user.Name == PowerUser;
        }
    }
}