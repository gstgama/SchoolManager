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
}