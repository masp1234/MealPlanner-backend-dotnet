using MealPlanner_backend.Data;
using MealPlanner_backend.Repositories;
using MealPlanner_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMealPlanService, MealPlanService>();

var app = builder.Build();

// Apply migrations at startup
await WaitForDatabaseStarted(app.Services.CreateScope(), connectionString);

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    try
    {
        dbContext.Database.Migrate(); // Apply pending migrations
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static async Task WaitForDatabaseStarted(IServiceScope scope, string connectionString)
{
    var retries = 30; // Number of retries
    var delay = TimeSpan.FromSeconds(5); // Delay between retries

    while (retries > 0)
    {
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            await dbContext.Database.GetDbConnection().OpenAsync(); // Try to open a connection
            break; // Exit loop if successful
        }
        catch (Exception)
        {
            retries--;
            Console.WriteLine($"Connection could not be established to the database. Retries left: {retries}");
            await Task.Delay(delay); // Wait before retrying
           
        }
    }
}
