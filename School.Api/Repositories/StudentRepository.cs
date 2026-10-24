using School.Data.Data;
using School.Data.Models;

namespace School.Api.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public async Task<bool> UpdateAsync(int id, Student model) 
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return false;

        student.FirstMidName = model.FirstMidName;
        student.LastName = model.LastName;

        await _context.SaveChangesAsync();
        return true;
    }

}

