using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApplication
{
    public static class HttpRequestHandler
    {
        public static HttpResponseMessage HandleHttpRequest(HttpListenerContext context, Controller controller)
        {
            string url = context.Request.Url.Segments.Last();
            // handle request, convert into something the user service understands and returning it 
            switch (context.Request.HttpMethod)
            {
                case "GET":
                {
                    return controller.Get(url);
                }
                case "PUT":
                {
                    //return controller.Put(context.Request.Url.Segments.Last());
                    break;
                }
                case "DELETE":
                {
                    //return controller.Delete(context.Request.Url.Segments.Last());
                    break;
                }
            }

            return new HttpResponseMessage();
        }
    }
}