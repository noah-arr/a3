using Microsoft.AspNetCore.Mvc;
using School.Api.Repositories;
using School.Data.Models;

namespace School.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _repository;
    public CourseController(ICourseRepository repository) => _repository = repository;

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
}
