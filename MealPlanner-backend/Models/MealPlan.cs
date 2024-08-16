using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner_backend.Models
{
    public class MealPlan
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        public MealPlan()
        {
        }
    }
}
