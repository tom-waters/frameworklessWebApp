using System;
using System.Collections.Generic;
using FluentAssertions;
using WebApplication;
using WebApplication.Data;
using WebApplication.Domain;
using Xunit;

namespace WebApplicationTests
{
    public class DatabaseTests : IDisposable
    {
        private IDatabase _database;
        
        public DatabaseTests()
        {
            InitialiseDatabase();
        }

        private void InitialiseDatabase()
        {
            _database = new Database();
        }

        public void Dispose()
        {
            InitialiseDatabase();
        }

        [Fact]
        public void NewDatabaseShouldContainPowerUser()
        {
            var users = _database.GetUsers();
            var powerUser = new User("Tom");

            users.Should().ContainEquivalentOf(powerUser);
        }
        
        [Fact]
        public void AddUsersShouldAddUserToDatabase()
        {
            var newUser = new User("Janet");
            _database.AddUser(newUser);
            var users = _database.GetUsers();

            users.Should().ContainEquivalentOf(newUser);
            users.Should().HaveCount(2);
        }

        [Fact]
        public void GetUsersShouldReturnAllUsers()
        {
            var userOne = new User("Janet");
            var userTwo = new User("Jill");
            _database.AddUser(userOne);
            _database.AddUser(userTwo);

            var expectedUsers = new List<User>()
            {
                new User("Tom"),
                new User("Janet"),
                new User("Jill")
            };
            var allUsers = _database.GetUsers();
            
            allUsers.Should().BeEquivalentTo(expectedUsers);
        }

        [Fact]
        public void DeleteUserShouldRemoveUserFromDatabase()
        {
            var newUser = new User("Janet");
            _database.AddUser(newUser);
            _database.DeleteUser(newUser);
            
            var users = _database.GetUsers();
            var expectedUsers = new List<User>() {new User("Tom")};

            users.Should().BeEquivalentTo(expectedUsers);
            users.Should().HaveCount(1);
        }

        [Fact]
        public void UpdateUserShouldChangeTheUsersName()
        {
            var newUser = new User("Janet");
            _database.AddUser(newUser);
            _database.UpdateUser(newUser, "Ted");

            var users = _database.GetUsers();
            var updatedUser = new User("Ted");

            users.Should().ContainEquivalentOf(updatedUser);

        }
    }
}