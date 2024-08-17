using MealPlanner_backend.Models;
using MealPlanner_backend.Repositories;

namespace MealPlanner_backend.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMealPlanRepository _mealPlanRepository;
        public MealPlanService(IMealPlanRepository mealPlanRepository)
        {
            this._mealPlanRepository = mealPlanRepository;
        }
        public async Task<List<MealPlan>> GetAllMealPlans()
        {
            return await _mealPlanRepository.GetAll();

        }
    }
}
