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
        
        public HttpResponseMessage GetUsers()
        {
            var users = _database.GetUsers();
            var message = Output.DisplayMessage(users);
            return CreateResponseContent(false, message, "GET");
        }
        
        public HttpResponseMessage GetUserList()
        {
            var users = _database.GetUsers();
            var responseInJson = JsonConvert.SerializeObject(users);
            return CreateResponseContent(false, responseInJson, "GET");
        }
        
        public HttpResponseMessage AddUser(User user)
        {
            var (success, response) = _database.AddUser(user);
            var responseInJson = JsonConvert.SerializeObject(user);
            if (!success)
            {
                responseInJson = JsonConvert.SerializeObject(response);
            }
            return CreateResponseContent(success, responseInJson, "PUT");
        }
        
        public HttpResponseMessage DeleteUser(User user)
        {
            var (success, content) = _database.DeleteUser(user);
            var responseInJson = "";
            if (!success)
            {
                responseInJson = JsonConvert.SerializeObject(content);
            }
            return CreateResponseContent(success, responseInJson, "DELETE");
        }

        public HttpResponseMessage UpdateUser(User oldName, string newName)
        {
            var (success, response) = _database.UpdateUser(oldName, newName);
            var responseInJson = JsonConvert.SerializeObject(oldName);
            if (!success)
            {
                responseInJson = JsonConvert.SerializeObject(response);
            }
            return CreateResponseContent(success, responseInJson, "POST");
        }
           
        private HttpResponseMessage CreateResponseContent(bool success, string message, string httpMethod)
        {
            var response = new HttpResponseMessage();
            var content = new StringContent(message);
            response.Content = content;
            response.StatusCode = FetchStatusCode(httpMethod, success);
            return response;
        }

        private HttpStatusCode FetchStatusCode(string httpMethod, bool success)
        {
            return (httpMethod, success) switch
            {
                ("PUT", true) => HttpStatusCode.Created,
                ("PUT", false) => HttpStatusCode.BadRequest,
                ("POST", true) => HttpStatusCode.OK,
                ("POST", false) => HttpStatusCode.BadRequest,
                ("DELETE", true) => HttpStatusCode.NoContent,
                ("DELETE", false) => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.OK
            };
        }
    }
}