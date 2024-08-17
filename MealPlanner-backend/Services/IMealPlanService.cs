using MealPlanner_backend.Models;

namespace MealPlanner_backend.Services
{
    public interface IMealPlanService
    {
        Task<List<MealPlan>> GetAllMealPlans();

    }
}