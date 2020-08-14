using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WebApplication.Data;
using WebApplication.Domain;

namespace WebApplication.Web
{
    public class Controller
    {
        private IDatabase _database = new Database();
        
        public HttpResponseMessage GetUser()
        {
            var users = _database.GetUsers();
            var message = Output.DisplayMessage(users);
            return CreateResponseContent(message, "GET");
        }
        
        public HttpResponseMessage GetUserList()
        {
            var users = _database.GetUsers();
            var json = JsonConvert.SerializeObject(users);
            return CreateResponseContent(json, "GET");
        }
        public HttpResponseMessage AddUser(User user)
        {
            _database.AddUser(user);
            var json = JsonConvert.SerializeObject(user);
            return CreateResponseContent(json, "PUT");
        }
        
        public HttpResponseMessage DeleteUser(User user)
        {
            _database.DeleteUser(user);
            var json = JsonConvert.SerializeObject(user);
            return CreateResponseContent(json, "DELETE");
        }

        public HttpResponseMessage UpdateUser(User oldName, string newName)
        {
            _database.UpdateUser(oldName, newName);
            var json = JsonConvert.SerializeObject(oldName);
            Console.WriteLine("HIT post");
            return CreateResponseContent(json, "POST");
        }
           
        private HttpResponseMessage CreateResponseContent(string message, string httpMethod)
        {
            var response = new HttpResponseMessage();
            var content = new StringContent(message);
            response.Content = content;
            response.StatusCode = FetchStatusCode(httpMethod);
            return response;
        }

        private HttpStatusCode FetchStatusCode(string httpMethod)
        {
            switch (httpMethod)
            {
                case "PUT":
                case "POST":
                    return HttpStatusCode.Created;
                default:
                    return HttpStatusCode.OK;
            }
        }



    }
}