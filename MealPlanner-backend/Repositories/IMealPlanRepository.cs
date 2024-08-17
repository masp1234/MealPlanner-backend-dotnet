using MealPlanner_backend.Models;

namespace MealPlanner_backend.Repositories
{
    public interface IMealPlanRepository
    {
        Task<List<MealPlan>> GetAll();
    }
}
