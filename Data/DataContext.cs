using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MealPlanner_backend.Models;

namespace MealPlanner_backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}