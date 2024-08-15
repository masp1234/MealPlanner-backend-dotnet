﻿using MealPlanner_backend.Models;
using MealPlanner_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return users;
        }
    }
}
