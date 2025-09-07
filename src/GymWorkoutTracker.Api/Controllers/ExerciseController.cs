using GymWorkoutTracker.Application.Interfaces.Services;
using GymWorkoutTracker.Domain.Entities;
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

    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] Exercise exercise, CancellationToken ct)
    {
        await _exerciseService.CreateAsync(exercise, ct);
        
        return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateExercise(int id, [FromBody] Exercise exercise, CancellationToken ct)
    {
        if (id != exercise.Id)
        {
            return BadRequest("ID mismatch between route and body");
        }

        await _exerciseService.UpdateAsync(exercise, ct);
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteExercise(int id, CancellationToken ct)
    {
        try
        {
            await _exerciseService.DeleteAsync(id, ct);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}