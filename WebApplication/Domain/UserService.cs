using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication.Data;

namespace WebApplication.Domain
{
    public class UserService
    {
        private IDatabase _database = new Database();

        public List<User> GetUsers()
        {
            return _database.GetUsers();
        }
        
        public void AddUser(User user)
        {
            _database.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            _database.DeleteUser(user);
        }

        public void UpdateUser(User oldName, User newName)
        {
            _database.UpdateUser(oldName, newName.Name);
        }
    }
}