using System.Net;

namespace WebApplication
{
    public class HttpServer : IHttpServer
    {
        public HttpListener CreateServer()
        {
            var server = new HttpListener();
            server.Prefixes.Add("http://localhost:8080/");
            return server;
        }
    }
}