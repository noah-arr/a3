using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Data;

namespace School.Web.Controllers;

public class InstructorController : Controller
{
    private readonly SchoolContext _context;
    public InstructorController(SchoolContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var instructors = await _context.Instructors.Include(i => i.CourseAssignments).ThenInclude(ca => ca.Course).OrderBy(i => i.LastName).ToListAsync();
        return View(instructors);
    }
}
