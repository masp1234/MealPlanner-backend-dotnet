using MealPlanner_backend.Repositories;
using MealPlanner_backend.Models;
using Microsoft.AspNetCore.Mvc;
namespace MealPlanner_backend.Services
{
    public class UserService
    {

        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
