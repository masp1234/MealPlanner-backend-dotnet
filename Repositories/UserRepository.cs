using MealPlanner_backend.Data;
using MealPlanner_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(user => user.Email == email);
            return user;
        }


        public async Task<User?> AddUser(User newUser)
            {
                _context.Users.Add(newUser);
                var result = await _context.SaveChangesAsync();
                if (result == 1)
                {
                    return newUser;
                }
                return null;
            }


        }

}
