using Microsoft.EntityFrameworkCore;
using SchoolManager.Domain.Entities;

namespace SchoolManager.Infrastructure.Data;

public class SchoolContext(DbContextOptions options) : DbContext(options)
{
    //TODO: Colocar log de query

    public DbSet<Student> Students { get; set; }
}