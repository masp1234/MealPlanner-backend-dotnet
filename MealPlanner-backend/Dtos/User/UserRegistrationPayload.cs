using System.ComponentModel.DataAnnotations;

namespace MealPlanner_backend.Dtos.User
{
    public class UserRegistrationPayload
    {
        [Required]
        public string Auth0UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CreatedAt { get; set; }
    }
}
