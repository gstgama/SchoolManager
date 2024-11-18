namespace SchoolManager.Domain.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student student);

    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student?> GetByIdAsync(Guid id);

    Task<bool> StudentExistsAsync(string name);
    
    Task UpdateAsync(Student student);
}