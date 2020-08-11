using System.Net;
using System.Net.Http;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WebApplication.Domain;

namespace WebApplication.Web
{
    public class Controller
    {
        UserService userService = new UserService();
        public HttpResponseMessage Get(string url)
        {
            var response = new HttpResponseMessage();
            var users = userService.GetUsers();
            
            if (url == "users")
            {
                var json = JsonConvert.SerializeObject(users);
                var content = new StringContent(json);
                response.Content = content;
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            else
            {
                var message = Output.DisplayMessage(users);
                var content = new StringContent(message);
                response.Content = content;
                return response;
            }
            
        }

        public string Put(string url)
        {
            return "";
        }

        public string Delete(string url)
        {
            return "";
        }
    }
}