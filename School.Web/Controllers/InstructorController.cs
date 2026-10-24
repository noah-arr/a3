using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Data;
using School.Data.Models;
using School.Web.Models;

namespace School.Web.Controllers;

public class InstructorController : Controller
{
    private readonly SchoolContext _context;
    public InstructorController(SchoolContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 4;

        var instructors = _context.Instructors.Include(i => i.CourseAssignments).ThenInclude(ca => ca.Course).OrderBy(i => i.LastName);
        return View(await PaginatedList<Instructor>.CreateAsync(instructors, page, pageSize));
    }
    public async Task<IActionResult> Edit(int? id) // get
    {
        if (id == null) return NotFound();
        var instructor = await _context.Instructors.FindAsync(id);
        if (instructor == null) return NotFound();
        return View(instructor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int? id, Instructor model)
    {
        var instructor = await _context.Instructors.FindAsync(id);
        if (instructor == null) return NotFound();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        instructor.FirstMidName = model.FirstMidName;
        instructor.LastName = model.LastName;
        instructor.HireDate = model.HireDate;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
