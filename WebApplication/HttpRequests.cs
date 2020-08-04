using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WebApplication
{
    public static class HttpRequests
    {
        public static string HandleDatabaseChanges(HttpListenerContext context, UserDatabase userDatabase)
        {
            string output = string.Empty;
            switch (context.Request.HttpMethod)
            {
                case "GET":
                {
                    if (context.Request.Url.Segments.Last() == "users")
                    {
                        output = Output.DisplayListOfNames(userDatabase);
                    }
                    else
                    {
                        output = Output.DisplayMessage(userDatabase);
                    }
                    break;
                }
                case "PUT":
                {
                    var user = context.Request.Url.Segments.Last();
                    if (userDatabase.AllUsers.Contains(user))
                    {
                        output = Output.UserAlreadyExistsMessage(user);
                        return output; 
                    }
                    userDatabase.AllUsers.Add(user.Trim('/'));
                    output = Output.UserAddedMessage(user);
                    break;
                }
                case "DELETE":
                {
                    var user = context.Request.Url.Segments.Last();
                    userDatabase.AllUsers.Remove(user.Trim('/'));
                    break;
                }
            }
            return output;
        }
    }
}