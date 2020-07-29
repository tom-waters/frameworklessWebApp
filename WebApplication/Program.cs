using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            server.Start();
            while (true)
            {
                var context = server.GetContext();
                Console.WriteLine($"{context.Request.HttpMethod} {context.Request.Url}");
                var buffer = System.Text.Encoding.UTF8.GetBytes(OutputMessage());
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            server.Stop();  // never reached...
        }

        private static string OutputMessage()
        {
            var outputMessage = $"Hello Tom - the time on the server is {TimeStamp.FormatDate(DateTime.Now)}.";
            var htmlFormat = "" +
                "<HTML>" +
                    "<BODY>" +
                        "<div style='color: darkslateblue'>" + 
                            $"{outputMessage}" +
                        "</div>" +
                    "</BODY" + 
                "</HTML>";
            return htmlFormat;
        }
    }
}