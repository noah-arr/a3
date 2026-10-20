using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Data;

namespace School.Web.Controllers;

public class CoursesController : Controller
{
    private readonly SchoolContext _context;
    public CoursesController(SchoolContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses.Include(c => c.Department).OrderBy(c => c.Title).ToListAsync();
        return View(courses);
    }
}
