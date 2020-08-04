using System.Collections.Generic;

namespace WebApplication
{
    public interface IDatabase
    {
        List<User> GetUsers();
        void AddUser(string user);
        void UpdateUser(string oldName, string newName);
        void DeleteUser(string user);

    }
}