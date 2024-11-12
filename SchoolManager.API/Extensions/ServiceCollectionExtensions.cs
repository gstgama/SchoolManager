using SchoolManager.Domain.Services.Implementations;
using SchoolManager.Domain.Services.Interfaces;
using SchoolManager.Domain.Repositories.Implementations;
using SchoolManager.Domain.Repositories.Interfaces;

namespace SchoolManager.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        RegisterServices(services);
        RegisterRepositories(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
    }
}