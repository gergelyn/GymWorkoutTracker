using GymWorkoutTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;
    
    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetExercise(int id, CancellationToken ct)
    {
        var exercise = await _exerciseService.GetByIdAsync(id, ct);
        if (exercise == null)
        {
            return NotFound();
        }
        
        return Ok(exercise);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExercises(CancellationToken ct)
    {
        var exercises = await _exerciseService.GetAllAsync(ct);
        
        return Ok(exercises);
    }
    
}