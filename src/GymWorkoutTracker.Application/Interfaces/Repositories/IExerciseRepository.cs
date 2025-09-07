using GymWorkoutTracker.Domain.Entities;

namespace GymWorkoutTracker.Application.Interfaces.Repositories;

public interface IExerciseRepository
{
    Task<Exercise?> GetByIdAsync(int id, CancellationToken ct);
    Task<IEnumerable<Exercise>> GetAllAsync(CancellationToken ct);
    Task CreateAsync(Exercise exercise, CancellationToken ct);
    Task UpdateAsync(Exercise exercise, CancellationToken ct);
    Task DeleteAsync(Exercise exercise, CancellationToken ct);
}