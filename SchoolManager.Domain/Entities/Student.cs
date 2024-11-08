namespace SchoolManager.Domain.Entities;

public class Student
{
    public Guid Id { get; private init; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;

    public int Age { get; private set; } = 0;
}