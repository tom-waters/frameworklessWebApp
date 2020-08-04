using System;
using System.Net;
using System.Collections.Generic;
using System.Xml.Schema;
using Microsoft.AspNetCore.Http;
using Moq;
using WebApplication;
using Xunit;

namespace WebApplicationTests
{
    public class UsersTests
    {
       [Fact]
        public void PUTRequestAddsUserToUsersList()
        {
            var server = new HttpServer().CreateServer();
            server.Start();
            
        }
    }
}