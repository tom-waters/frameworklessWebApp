using System.Collections.Generic;
using WebApplication.Domain;

namespace WebApplication
{
    public interface IDatabase
    {
        List<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user, string newName);
        void DeleteUser(User user);

    }
}