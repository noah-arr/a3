using Microsoft.EntityFrameworkCore;
using School.Data.Data;
using School.Data.Models;

namespace School.Api.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly SchoolContext _context;

    public CourseRepository(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllAsync() => await _context.Courses.Include(c => c.Department).OrderBy(c => c.Title).ToListAsync();
    public async Task<Course> GetByIdAsync(int id) => await _context.Courses.Include(c => c.Department).FirstOrDefaultAsync(c => c.CourseId == id);

}
