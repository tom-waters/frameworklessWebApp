using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Domain;
using Controller = WebApplication.Web.Controller;

namespace WebApplication.Http
{
    public static class HttpRequestHandler
    {
        public static HttpResponseMessage HandleHttpRequest(HttpListenerContext context, Controller controller)
        {
            var resource = context.Request.Url.Segments.Last().Trim('/');
            
            var requestBody= FetchRequestBody(context);
            var user = new User(resource);

            switch (context.Request.HttpMethod)
            {
                case "GET":
                {
                    return resource == "users" ? controller.GetUserList() : controller.GetUser();
                }
                case "PUT":
                {
                    return controller.AddUser(user);
                } 
                case "POST":
                {
                    return controller.UpdateUser(user, requestBody.Name);
                }
                case "DELETE":
                {
                    return controller.DeleteUser(user);
                }
            }

            return new HttpResponseMessage();
        }

        private static User FetchRequestBody(HttpListenerContext context)
        {
            Stream stream = context.Request.InputStream;
            StreamReader streamReader = new StreamReader(stream);
            JsonSerializer serializer = new JsonSerializer();
            return (User) serializer.Deserialize(streamReader, typeof(User));
        }
    }
}