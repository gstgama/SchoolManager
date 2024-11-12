using SchoolManager.Domain.Repositories.Interfaces;
using SchoolManager.Domain.Services.Interfaces;

namespace SchoolManager.Domain.Services.Implementations;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<IEnumerable<StudentDTO>> GetAllAsync()
    {
        IEnumerable<Student> students = await _studentRepository.GetAllAsync();

        return students.Select(x => new StudentDTO(x.Id, x.Name, x.Age));
    }
}