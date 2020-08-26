using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Domain;
using WebApplication.Http;
using WebApplication.Web;

namespace WebApplication
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var server = new HttpServer().CreateServer();
            var controller = new Controller();
            server.Start();
            Console.WriteLine("Server running...");
            while (true)
            {
                var context = server.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var response = HttpRequestHandler.HandleHttpRequest(context, controller);
                var content = response.Content.ReadAsStringAsync().Result;
                var buffer = Encoding.UTF8.GetBytes(content);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.StatusCode = (int) response.StatusCode;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                
                context.Response.Close();
            }
        }
    }
}