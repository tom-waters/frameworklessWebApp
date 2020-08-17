using System;
using System.Collections.Generic;
using WebApplication.Domain;

namespace WebApplication
{
    public interface IDatabase
    {
        List<User> GetUsers();
        Tuple<bool, string> AddUser(User user);
        Tuple<bool, string> UpdateUser(User user, string newName);
        Tuple<bool, string>  DeleteUser(User user);

    }
}