using MealPlanner_backend.Repositories;
using MealPlanner_backend.Models;
namespace MealPlanner_backend.Services
{
    public class UserService
    {

        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }
    }
}
