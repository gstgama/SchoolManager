using Microsoft.EntityFrameworkCore;
using SchoolManager.Domain.Data;
using SchoolManager.Domain.Repositories.Interfaces;

namespace SchoolManager.Domain.Repositories.Implementations;

public class StudentRepository(SchoolContext context) : IStudentRepository
{
    private readonly SchoolContext _context = context;

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> StudentExistsAsync(string name)
    {
        return await _context.Students
            .Where(x => x.Name.Trim().ToUpper() == name)
            .AnyAsync();
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _context.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Update(student);
        await _context.SaveChangesAsync();
    }
}