using MealPlanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner_backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(user => user.MealPlans)
            .WithOne(mealPlan => mealPlan.User)
            .HasForeignKey(mealPlan => mealPlan.UserId);    
    }
}