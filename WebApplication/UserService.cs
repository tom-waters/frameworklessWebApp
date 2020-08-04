using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Schema;

namespace WebApplication
{
    public static class UserService
    {
        public static IDatabase Database = new Database();
        public static string GetRequest(HttpListenerContext context)
        {
            if (context.Request.Url.Segments.Last() == "users")
            {
                return "JSON object of all users";
            }
            else
            {
                return "Greeting message";
            }
        }

        public static string PutRequest(HttpListenerContext context)
        {
            
            if (context.Request.Url.ToString().Contains("="))
            {
                
                return "201 and JSON object";
            }
            else
            {
                return "add name";
            }
            // return JSON object of updated user
            return "";
        }

        public static void DeleteRequest(HttpListenerContext context)
        {
            
        }
        
        public static string AddUser(HttpListenerContext context)
        {
            // return JSON object on added user
            return "";
        }

    }
}