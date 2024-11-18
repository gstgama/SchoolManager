using SchoolManager.Domain.Repositories.Interfaces;
using SchoolManager.Domain.Services.Interfaces;

namespace SchoolManager.Domain.Services.Implementations;

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    public async Task<Result<IEnumerable<StudentDTO>>> GetAllAsync()
    {
        try
        {
            IEnumerable<Student> students = await _studentRepository.GetAllAsync();

            return Result<IEnumerable<StudentDTO>>.Success(students.Select(x => new StudentDTO(x.Id, x.Name, x.Age)));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<StudentDTO>>.Failure(ex.Message);
        }
    }

    public async Task<Result<StudentDTO>> GetByIdAsync(Guid id)
    {
        try
        {
            Student? student = await _studentRepository.GetByIdAsync(id);

            if (student is null)
            {
                return Result<StudentDTO>.Failure();
            }

            return Result<StudentDTO>.Success(new StudentDTO(student.Id, student.Name, student.Age));

        }
        catch (Exception ex)
        {
            return Result<StudentDTO>.Failure(ex.Message);
        }
    }

    public async Task<Result<StudentDTO>> CreateAsync(string name, int age)
    {
        try
        {
            bool studentExists = await _studentRepository.StudentExistsAsync(name);

            if (studentExists) 
            {
                return Result<StudentDTO>.Failure("Student already exists");
            }

            Student student = Student.Create(name, age);

            Student entity = await _studentRepository.CreateAsync(student);

            return Result<StudentDTO>.Success(new StudentDTO(entity.Id, entity.Name, entity.Age));
        }
        catch (Exception ex)
        {
            return Result<StudentDTO>.Failure(ex.Message);
        }
    }

    public async Task<Result<StudentDTO>> UpdateAsync(Guid id, string name, int age)
    {
        try
        {
            Student? student = await _studentRepository.GetByIdAsync(id);

            if (student is null)
            {
                return Result<StudentDTO>.Failure("Student not found");
            }

            student.Update(name, age);

            await _studentRepository.UpdateAsync(student);

            return Result<StudentDTO>.Success(new StudentDTO(student.Id, student.Name, student.Age));
        }
        catch (Exception ex)
        {
            return Result<StudentDTO>.Failure(ex.Message);
        }
    }
}