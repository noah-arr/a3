using Microsoft.EntityFrameworkCore;
using School.Data.Data;
using School.Data.Models;

namespace School.Api.Repositories;

public class InstructorRepository : IInstructorRepository
{
    private readonly SchoolContext _context;

    public InstructorRepository(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<Instructor>> GetAllAsync() => await _context.Instructors.Include(i => i.CourseAssignments).ThenInclude(ca => ca.Course).OrderBy(i => i.LastName).ToListAsync();
    public async Task<Instructor> GetByIdAsync(int id) => await _context.Instructors.Include(i => i.CourseAssignments).ThenInclude(ca => ca.Course).FirstOrDefaultAsync(i => i.Id == id);
    public async Task<bool> UpdateAsync(int id, Instructor model)
    {
        var instructor = await _context.Instructors.FindAsync(id);
        if (instructor == null) return false;

        instructor.FirstMidName = model.FirstMidName;
        instructor.LastName = model.LastName;
        instructor.HireDate = model.HireDate;

        await _context.SaveChangesAsync();
        return true;
    }
}
