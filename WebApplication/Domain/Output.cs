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
    }
}