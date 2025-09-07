using GymWorkoutTracker.Application.Interfaces.Repositories;
using GymWorkoutTracker.Domain.Entities;
using GymWorkoutTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymWorkoutTracker.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;
    
    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Exercise?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _context.Exercises .FirstOrDefaultAsync(e=> e.Id == id, ct);
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync(CancellationToken ct)
    {
        return await _context.Exercises.ToListAsync(ct);
    }

    public async Task CreateAsync(Exercise exercise, CancellationToken ct)
    {
        await _context.Exercises.AddAsync(exercise, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Exercise exercise, CancellationToken ct)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Exercise exercise, CancellationToken ct)
    {
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync(ct);
    }
}