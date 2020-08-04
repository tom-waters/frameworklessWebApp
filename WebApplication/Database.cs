using System.Collections.Generic;
using System.Linq;

namespace WebApplication
{
    public class Database : IDatabase
    {
        private const string PowerUser = "Tom";
        public List<User> AllUsers = new List<User> { new User(PowerUser)};

        public List<User> GetUsers()
        {
            return AllUsers;
        }
        
        public void AddUser(string user)
        {
            AllUsers.Add(new User(user.Trim('/')));
        }

        public void UpdateUser(string oldName, string newName)
        {
            foreach (var user in AllUsers.Where(user => user.Name == oldName))
            {
                user.Name = newName;
            }
        }

        public void DeleteUser(string userName)
        {
            foreach (var user in AllUsers.Where( user => user.Name == userName))
            {
                AllUsers.Remove(user);
            }
        }
        
    }
}