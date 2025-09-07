using GymWorkoutTracker.Application.Interfaces.Repositories;
using GymWorkoutTracker.Application.Interfaces.Services;
using GymWorkoutTracker.Infrastructure.Data;
using GymWorkoutTracker.Infrastructure.Repositories;
using GymWorkoutTracker.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymWorkoutTracker.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        return services;
    }
}