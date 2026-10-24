using Microsoft.AspNetCore.Mvc;
using School.Api.Repositories;
using School.Data.Models;

namespace School.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly IInstructorRepository _repository;
    public InstructorController(IInstructorRepository repository) => _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] Instructor model)
    {
        var updated = await _repository.UpdateAsync(id, model);

        if (!updated)
            return NotFound();

        return NoContent();
    }
}
