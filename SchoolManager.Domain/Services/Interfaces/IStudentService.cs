namespace SchoolManager.Domain.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDTO>> GetAllAsync();
}