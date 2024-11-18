namespace SchoolManager.Domain.Services.Interfaces;

public interface IStudentService
{
    Task<Result<StudentDTO>> CreateAsync(string name, int age);

    Task<Result<IEnumerable<StudentDTO>>> GetAllAsync();

    Task<Result<StudentDTO>> GetByIdAsync(Guid id);

    Task<Result<StudentDTO>> UpdateAsync(Guid id, string name, int age);
}