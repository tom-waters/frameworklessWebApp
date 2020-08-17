using System.Net;

namespace WebApplication.Http
{
    public interface IHttpServer
    {
        abstract HttpListener CreateServer();
    }
}