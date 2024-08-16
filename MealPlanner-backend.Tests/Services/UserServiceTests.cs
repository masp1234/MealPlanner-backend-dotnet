using MealPlanner_backend.Dtos.User;
using MealPlanner_backend.Models;
using MealPlanner_backend.Repositories;
using MealPlanner_backend.Services;
using Moq;

namespace MealPlanner_backend.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var testUsers = new List<User>
            {
                new() { AuthId = "TestID", Name = "bob", Email = "email1@gmail.com" },
                new() { AuthId = "TestID2", Name = "bob2", Email = "email2@gmail.com" }
            };

            mockRepo.Setup(repo => repo.GetAllUsers()).ReturnsAsync(testUsers);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.GetAllUsers();


            // Assert
            Assert.Equal(testUsers, result);
        }
        [Fact]
        public async Task GetUser_ExistingUser_ReturnsUser()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            var testUser = new User { Id = 1, AuthId = "TestID", Name = "bob", Email = "email1@gmail.com" };
            mockRepo.Setup(repo => repo.GetUser(1)).ReturnsAsync(testUser);

            var service = new UserService(mockRepo.Object);

            // Act
            var result = await service.GetUser(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testUser.Id, result?.Id);
            Assert.Equal(testUser.Name, result?.Name);
            Assert.Equal(testUser.Email, result?.Email);
        }

        [Fact]
        public async Task GetUser_NonExistingUser_ReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();

            var service = new UserService(mockRepo.Object);

            User? nonExistingUser = null;

            mockRepo.Setup(repo => repo.GetUser(99)).ReturnsAsync(nonExistingUser);

            // Act 
            var result = await service.GetUser(1);

            // Assert
            Assert.Null(result);
            
        }

        [Fact]
        public async Task AddUser_NoExistingUser_ReturnsNewUser()
        {
            var mockRepo = new Mock<IUserRepository>();

            var service = new UserService(mockRepo.Object);

            var payload = new UserRegistrationPayload
            {
                Auth0UserId = "newUserId",
                Name = "Test",
                Email = "test@gmail.com"
            };

            mockRepo.Setup(repo => repo.GetUserByEmail(payload.Email)).ReturnsAsync((User?)null);
            mockRepo.Setup(repo => repo.AddUser(It.IsAny<User>())).ReturnsAsync(new User
            {
                AuthId = payload.Auth0UserId,
                Name = payload.Name,
                Email = payload.Email
            });

            // Act
            var result = await service.AddUser(payload);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(payload.Auth0UserId, result?.AuthId);
            Assert.Equal(payload.Name, result?.Name);
            Assert.Equal(payload.Email, result?.Email);
        }

        [Fact]
        public async Task AddUser_ExistingUser_ThrowsException()
        {
            // Arrange

            var mockRepo = new Mock<IUserRepository>();

            var service = new UserService(mockRepo.Object);

            var payload = new UserRegistrationPayload
            {
                Auth0UserId = "newUserId",
                Name = "New User",
                Email = "existinguser@example.com"
            };

            var existingUser = new User
            {
                AuthId = "existingUserId",
                Name = "Existing User",
                Email = payload.Email
            };

            mockRepo.Setup(repo => repo.GetUserByEmail(payload.Email)).ReturnsAsync(existingUser);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => service.AddUser(payload));
            Assert.Equal($"User with email: '{payload.Email}' already exists.", exception.Message);
        }
    }

    }
