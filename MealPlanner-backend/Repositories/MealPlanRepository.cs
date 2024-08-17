using MealPlanner_backend.Data;
using MealPlanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner_backend.Repositories
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly DataContext _dataContext;
        public MealPlanRepository(DataContext context)
        {
            this._dataContext = context;
        }
        public async Task<List<MealPlan>> GetAll()
        {
            return await _dataContext.MealPlans.ToListAsync();
        }
    }
}
