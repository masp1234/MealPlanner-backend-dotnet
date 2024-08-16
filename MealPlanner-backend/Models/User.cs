using System.ComponentModel.DataAnnotations;

namespace MealPlanner_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<MealPlan> MealPlans { get; set; }

        public User(string authId, string name, string email)
        {
            AuthId = authId;
            Name = name;
            Email = email;
        }

        public User()
        {
        }
    }
}
