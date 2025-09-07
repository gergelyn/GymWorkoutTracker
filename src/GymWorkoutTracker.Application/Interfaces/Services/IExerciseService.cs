using GymWorkoutTracker.Domain.Entities;

namespace GymWorkoutTracker.Application.Interfaces.Services;

public interface IExerciseService
{
    Task<Exercise?> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<Exercise>> GetAllAsync(CancellationToken ct);
    Task CreateAsync(Exercise exercise, CancellationToken ct);
    Task UpdateAsync(Exercise exercise, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}