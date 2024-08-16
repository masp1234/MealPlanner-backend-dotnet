using MealPlanner_backend.Models;

namespace MealPlanner_backend.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(int id);
        Task<User?> GetUserByEmail(string email);
        Task<User?> AddUser(User newUser);

    }
}
