using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Schema;

namespace WebApplication
{
    public class UserService
    {
        public IDatabase _database = new Database();

        public List<User> GetUsers()
        {
            return _database.GetUsers();
        }
        public string GetRequest(HttpListenerContext context)
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

        public string PutRequest(HttpListenerContext context)
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

        public void DeleteRequest(HttpListenerContext context)
        {
            
        }
        
        public string AddUser(HttpListenerContext context)
        {
            // return JSON object on added user
            return "";
        }
        
    }
}