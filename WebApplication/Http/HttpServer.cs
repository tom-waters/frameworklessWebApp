using System.Net;

namespace WebApplication.Http
{
    public class HttpServer : IHttpServer
    {
        public HttpListener CreateServer()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://*:8080/");
            return server;
        }
    }
}