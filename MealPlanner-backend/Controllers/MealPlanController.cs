using MealPlanner_backend.Models;
using MealPlanner_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealPlanController(IMealPlanService mealPlanService) : ControllerBase
    {
        private readonly IMealPlanService _mealPLanService = mealPlanService;

        // TODO Hvordan får man mealPlans med når man fetcher users?
        [HttpGet]
        public async Task<ActionResult<List<MealPlan>>> GetAllMealPlans()
        {
            try
            {
                var mealPlans = await _mealPLanService.GetAllMealPlans();
                return Ok(mealPlans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("An error occured, please try again later.");
            }
        }
    }
}
