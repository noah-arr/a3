using Microsoft.AspNetCore.Mvc;
using School.Api.Repositories;
using School.Data.Models;

namespace School.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _repository;
    public StudentController(IStudentRepository repository) => _repository = repository;
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] Student model)
    {
        var updated = await _repository.UpdateAsync(id, model);

        if (!updated)
            return NotFound();

        return NoContent();
    }
}
