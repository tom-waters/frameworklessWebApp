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

namespace WebApplication
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var server = new HttpServer().CreateServer();
            server.Start();
            while (true)
            {
                var context = server.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                HttpRequestHandler.HandleHttpRequest(context);
                
                
                var displayOutput = "sent";
               
                var buffer = Encoding.UTF8.GetBytes(displayOutput);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();
            }
        }
    }
}