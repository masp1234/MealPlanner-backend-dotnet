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

    }
}
