using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;

namespace WebApplication.Domain
{
    public class Output
    {
        
        public static string DisplayMessage(List<User> users)
        {
            return $"Hello {DisplayUsersInString(users)} - the time on the server is {TimeStamp.FormatDate(DateTime.Now)}.";
        }

        private static string DisplayUsersInString(List<User> users)
        {
            var output = "";
            foreach (var user in users)
            {
                output += string.Join(" & ", user.Name);
            }
            return output;
        }

        public static string DisplayListOfNames(Database database)
        {
            return database.AllUsers.Aggregate("Users on server: ", (current, user) => current + $"\n{user}");
        }

        public static string UserAlreadyExistsMessage(string user)
        {
            return $"{user} already exists";
        }
        
        public static string UserAddedMessage(string user)
        {
            return $"{user} has been added";
        }
        
        public static string UserDeletedMessage(string user)
        {
            return $"{user} has been deleted";
        }
    }
}