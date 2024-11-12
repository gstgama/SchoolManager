namespace SchoolManager.Domain.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
}