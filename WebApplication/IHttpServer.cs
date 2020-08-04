using System.Net;

namespace WebApplication
{
    public interface IHttpServer
    {
        abstract HttpListener CreateServer();
    }
}