using MealPlanner_backend.Dtos.User;
using MealPlanner_backend.Models;

namespace MealPlanner_backend.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetUser(int id);

        Task<User?> AddUser(UserRegistrationPayload payload);
    }
}
