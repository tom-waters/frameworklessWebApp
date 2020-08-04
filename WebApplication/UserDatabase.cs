using System.Collections.Generic;

namespace WebApplication
{
    public class UserDatabase
    {
        private const string _powerUser = "Tom";
        public List<string> AllUsers = new List<string>() {_powerUser};

        public void GetListOfUsers()
        {
            
        }
        
        public void AddUser(string user)
        {
            AllUsers.Add(user.Trim('/'));
        }

        public void ChangeUserName(string oldName, string newName)
        {
            AllUsers[AllUsers.FindIndex(index => index.Equals(oldName))] = newName;
        }

        public void DeleteUser(string user)
        {
            AllUsers.Remove(user);
        }
        
    }
}