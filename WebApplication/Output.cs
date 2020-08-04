using System;
using System.Linq;

namespace WebApplication
{
    public class Output
    {
        
        public static string DisplayMessage(Database database)
        {
            return $"Hello {DisplayUsersInString(database)} - the time on the server is {TimeStamp.FormatDate(DateTime.Now)}.";
        }

        public static string DisplayUsersInString(Database database)
        {
            var output = "";
            output += string.Join(" & ", database.AllUsers);
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