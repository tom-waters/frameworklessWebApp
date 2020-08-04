using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WebApplication
{
    public static class HttpRequestHandler
    {
        public static void HandleHttpRequest(HttpListenerContext context)
        {
            // handle request, convert into something the user service understands and returning it 
            switch (context.Request.HttpMethod)
            {
                case "GET":
                {
                    UserService.GetRequest(context);
                    break;
                }
                case "PUT":
                {
                    UserService.PutRequest(context);
                    break;
                }
                case "DELETE":
                {
                    UserService.DeleteRequest(context);
                    break;
                }
            }
        }
    }
}