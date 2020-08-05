using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApplication
{
    public class Controller
    {
        UserService userService = new UserService();
        public HttpResponseMessage Get(string url)
        {
            var response = new HttpResponseMessage();
            if (url == "users")
            {
                var users = userService.GetUsers();
                        
                var json = JsonConvert.SerializeObject(users);
                var str = new StringContent(json);
                response.Content = str;
                response.StatusCode = HttpStatusCode.BadRequest;

                return response;
            }

            return response;
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