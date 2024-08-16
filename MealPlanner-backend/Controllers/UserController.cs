using MealPlanner_backend.Dtos.User;
using MealPlanner_backend.Models;
using MealPlanner_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {

        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("An error occurred, please try again later");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserRegistrationPayload payload)
        {
            if (payload is null)
            {
                return BadRequest("Missing payload.");
            }
            try
            {
                User? user = await _userService.AddUser(payload);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
