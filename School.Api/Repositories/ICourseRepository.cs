using School.Data.Models;

namespace School.Api.Repositories;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<Course> GetByIdAsync(int id);
}
