using System.ComponentModel.DataAnnotations;

namespace MealPlanner_backend.Dtos.MealPlan
{
    public class MealPlanCreateRequest
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }


    }
}
