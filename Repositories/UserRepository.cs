using MealPlanner_backend.Data;
using MealPlanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner_backend.Repositories
{
    public class UserRepository
    {

        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;

        }

        public async Task<User?> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }

    
}
