using GymWorkoutTracker.Application.Interfaces.Repositories;
using GymWorkoutTracker.Application.Interfaces.Services;
using GymWorkoutTracker.Domain.Entities;

namespace GymWorkoutTracker.Infrastructure.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }


    public async Task<Exercise?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _exerciseRepository.GetByIdAsync(id, ct);
    }

    public async Task<IEnumerable<Exercise>> GetAllAsync(CancellationToken ct)
    {
        return await _exerciseRepository.GetAllAsync(ct);
    }

    public async Task CreateAsync(Exercise exercise, CancellationToken ct)
    {
        await _exerciseRepository.CreateAsync(exercise, ct);
    }

    public async Task UpdateAsync(Exercise exercise, CancellationToken ct)
    {
        await _exerciseRepository.UpdateAsync(exercise, ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(id, ct);
        if (exercise == null)
        {
            throw new KeyNotFoundException($"Exercise with ID {id} not found.");
        }

        await _exerciseRepository.DeleteAsync(exercise, ct);
    }
}