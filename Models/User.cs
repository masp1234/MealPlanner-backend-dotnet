namespace MealPlanner_backend.Models
{
    public class User
    {
        public int Id {  get; set; }

        public string AuthId {  get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public User(string authId, string name, string email)
        {
            AuthId = authId;
            Name = name;
            Email = email;
        }
    }
}
