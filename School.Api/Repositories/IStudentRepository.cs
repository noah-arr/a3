using School.Data.Models;

namespace School.Api.Repositories;

public interface IStudentRepository
{
    Task<bool> UpdateAsync(int id, Student model);
}
