namespace MealPlanner_backend.Dtos.User
{
    public class UserRegistrationPayload
    {
        public string Auth0UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string CreatedAt { get; set; }
    }
}
