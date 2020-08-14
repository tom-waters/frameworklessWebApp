using System.IO;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication;
using WebApplication.Data;
using WebApplication.Domain;
using WebApplication.Web;
using Xunit;
using Controller = WebApplication.Web.Controller;

namespace WebApplicationTests
{
    public class ControllerTests
    {
      
        [Fact]
        public void GetUsersReturnsTheCorrectResponseMessage()
        {
            var controller = new Controller();
            var users = controller.GetUsers();
            users.Should().BeEquivalentTo("Tom");
        }

        [Fact]
        public void GetUserListReturnsTheCorrectResponseMessage()
        {
            var controller = new Controller();
            var users = controller.GetUserList();
            
            
            var response = new HttpResponseMessage();
            var responseInJson = JsonConvert.SerializeObject(users);
            var content = new StringContent(responseInJson);
            
            response.Content = content;
            response.StatusCode = HttpStatusCode.OK;
            
            JToken expectedResponse = JToken.Parse(@"{ ""Name"": ""Tom""}");
          

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