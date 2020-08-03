using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.ListenToHTTP();
        }

        private void ListenToHTTP()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            server.Start();
            while (true)
            {
                HttpListenerContext ctx = server.GetContext();
                ThreadPool.QueueUserWorkItem((_) =>
                {
                    string methodName = ctx.Request.Url.Segments[1].Replace("/", "");
                    string[] strParams = ctx.Request.Url
                        .Segments
                        .Skip(2)
                        .Select(s => s.Replace("/", ""))
                        .ToArray();

                    var method = this.GetType().GetMethod(methodName);
                    // object[] @params = method.GetParameters()
                    //     .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
                    //     .ToArray();

                    // object ret = method.Invoke(this, @params);
                    // string retstr = JsonConvert.SerializeObject(ret);

                    Console.WriteLine("ctx request: " + ctx.Request.Url);
                    Console.WriteLine("methodname: " + methodName);
                    foreach (var param in strParams)
                    {
                        Console.WriteLine("para: " + param);
                    }
                    // Console.WriteLine("strParams: " + strParams);
                    Console.WriteLine("method: " + method);
                    // Console.WriteLine("@params: " + @params);
                });
            }
        }
        

        // }
        //     server.Stop();  // never reached...
        // }
        //
        // private static string OutputMessage()
        // {
        //     var outputMessage = $"Hello {users} - the time on the server is {TimeStamp.FormatDate(DateTime.Now)}.";
        //     var htmlFormat = "" +
        //         "<HTML>" +
        //             "<BODY>" +
        //                 "<div style='color: darkslateblue'>" + 
        //                     $"{outputMessage}" +
        //                 "</div>" +
        //             "</BODY" + 
        //         "</HTML>";
        //     return htmlFormat;
        // }
    }
}