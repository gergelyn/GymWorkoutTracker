using System.Reflection;
using GymWorkoutTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutTracker.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}