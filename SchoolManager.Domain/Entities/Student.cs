namespace SchoolManager.Domain.Entities;

public class Student
{
    public Guid Id { get; private init; } = Guid.NewGuid();

    public string Name { get; private set; } = string.Empty;

    public int Age { get; private set; } = 0;

    public static Student Create(string name, int age)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Age = age
        };
    }

    public void Update(string name, int age)
    {
        Name = name;
        Age = age;
    }
}