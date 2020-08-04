using System;
using System.Linq;

namespace WebApplication
{
    public class Output
    {
        
        public static string DisplayMessage(UserDatabase userDatabase)
        {
            return $"Hello{DisplayUsersInString(userDatabase)} - the time on the server is {TimeStamp.FormatDate(DateTime.Now)}.";
        }

        public static string DisplayUsersInString(UserDatabase userDatabase)
        {
            var punctuation = "";
            if (userDatabase.AllUsers.Count > 1)
            {
                punctuation = " & ";
            }
            return userDatabase.AllUsers.Aggregate("", (current, user) => current + $"{user}{punctuation}");
        }

        public static string DisplayListOfNames(UserDatabase userDatabase)
        {
            return userDatabase.AllUsers.Aggregate("Users on server: ", (current, user) => current + $"\n{user}");
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