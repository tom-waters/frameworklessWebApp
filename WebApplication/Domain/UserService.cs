using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplication.Data;

namespace WebApplication.Domain
{
    public class UserService
    {
        private IDatabase _database = new Database();

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