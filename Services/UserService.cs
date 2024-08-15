using MealPlanner_backend.Repositories;
using MealPlanner_backend.Models;
using MealPlanner_backend.Dtos.User;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
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

        public async Task<User?> AddUser(UserRegistrationPayload payload)
        {
            User? userAlreadyExists = await _userRepository.GetUserByEmail(payload.Email);

            if (userAlreadyExists != null)
            {
                throw new Exception($"User with email: '{payload.Email}' already exists.");
            }

            User newUser = new (payload.Auth0UserId,
                                    payload.Name,
                                    payload.Email);

            return await _userRepository.AddUser(newUser);
            
        }
    }
}
