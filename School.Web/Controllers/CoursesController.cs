using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data.Data;
using School.Data.Models;

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
        var courses = await _context.Courses.Include(c => c.Department).Include(c => c.Enrollments).ThenInclude(s => s.Student).OrderBy(c => c.Title).ToListAsync();
        return View(courses);
    }

    public async Task<IActionResult> Edit(int? id) // get
    {
        if (id == null) return NotFound();
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();

        await LoadDepartmentsAsync(course.DepartmentId);
        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int? id, Course model)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();

        if (!ModelState.IsValid)
        {
            await LoadDepartmentsAsync(model.DepartmentId);
            return View(model);
        }

        course.Title = model.Title;
        course.Credits = model.Credits;
        course.DepartmentId = model.DepartmentId;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDepartmentsAsync(int selectedId) => ViewBag.Departments = new SelectList(
        await _context.Departments.OrderBy(d => d.Name).ToListAsync(),
        "DepartmentId", "Name", selectedId);
}
