using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WebApplication.Domain;

namespace WebApplication.Web
{
    public class Controller
    {
        UserService userService = new UserService();
        
        public HttpResponseMessage GetUser()
        {
            var users = userService.GetUsers();
            var message = Output.DisplayMessage(users);
            return CreateResponseContent(message, "GET");
        }
        
        public HttpResponseMessage GetUserList()
        {
            var users = userService.GetUsers();
            var json = JsonConvert.SerializeObject(users);
            return CreateResponseContent(json, "GET");
        }
        public HttpResponseMessage AddUser(User user)
        {
            userService.AddUser(user);
            var json = JsonConvert.SerializeObject(user);
            return CreateResponseContent(json, "PUT");
        }
        
        public HttpResponseMessage DeleteUser(User user)
        {
            userService.DeleteUser(user);
            var json = JsonConvert.SerializeObject(user);
            return CreateResponseContent(json, "DELETE");
        }

        public HttpResponseMessage UpdateUser(User oldName, User newName)
        {
            userService.UpdateUser(oldName, newName);
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