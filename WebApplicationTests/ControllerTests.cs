using System.IO;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication;
using WebApplication.Data;
using WebApplication.Domain;
using WebApplication.Web;
using Xunit;
using Controller = WebApplication.Web.Controller;

namespace WebApplicationTests
{
    public class ControllerTests
    {
        [Fact]
        public void GetUserListReturnsTheCorrectResponseMessage()
        {
            var controller = new Controller();
            var responseMessage = controller.GetUserList();
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.OK;
            var expectedBodyContent = @"[{""Name"":""Tom""}]";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }
        
        [Fact]
        public void AddUserReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var newUser = new User("Mary");
            var responseMessage = controller.AddUser(newUser);
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.Created;
            var expectedBodyContent = @"{""Name"":""Mary""}";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }
        
        [Fact]
        public void AddUserFailureReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var newUser = new User("Mary");
            controller.AddUser(newUser);
            var responseMessage = controller.AddUser(newUser);
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.BadRequest;
            var expectedBodyContent = @"""User already exists""";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }

        [Fact]
        public void DeleteUserReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var newUser = new User("Mary");
            controller.AddUser(newUser);
            var responseMessage = controller.DeleteUser(newUser);
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.NoContent;
            var expectedBodyContent = @"";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }
        
        [Fact]
        public void DeleteUserFailureReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var responseMessage = controller.DeleteUser(new User("Mary"));
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.BadRequest;
            var expectedBodyContent = @"""User doesn't exist""";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }

        [Fact]
        public void UpdateUserReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var userToUpdate = new User("Mary");
            controller.AddUser(userToUpdate);
            var responseMessage = controller.UpdateUser(userToUpdate, "Ted");
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.OK;
            var expectedBodyContent = @"{""Name"":""Ted""}";

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }
        
        [Fact]
        public void UpdateUserFailureReturnsCorrectResponseMessage()
        {
            var controller = new Controller();
            var userToUpdate = new User("Mary");
            controller.AddUser(userToUpdate);
            var responseMessage = controller.UpdateUser(new User("James"), "Ted");
            var responseBodyContent = responseMessage.Content.ReadAsStringAsync();

            var expectedResponseCode = HttpStatusCode.BadRequest;
            var expectedBodyContent = @"""User doesn't exist""";;

            responseMessage.StatusCode.Should().Be(expectedResponseCode);
            responseBodyContent.Result.Should().Be(expectedBodyContent);
        }
        
        
    }
}