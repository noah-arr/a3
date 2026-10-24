using School.Data.Models;

namespace School.Api.Repositories;

public interface IInstructorRepository
{
    Task<List<Instructor>> GetAllAsync();
    Task<Instructor> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, Instructor model);   // true = found and saved, false = not found
}
