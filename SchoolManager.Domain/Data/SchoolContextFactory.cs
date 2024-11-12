using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SchoolManager.Domain.Data;

public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
{
    public SchoolContext CreateDbContext(string[] args)
    {
        //TODO: Entender pq nao esta dando para rodar o comando dotnet ef database update
        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile(@"..\..\SchoolManager.API\appsettings.json")
        //    .Build();

        //TODO: Melhorar local da connection string
        DbContextOptionsBuilder<SchoolContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SchoolManager;Trusted_Connection=True;TrustServerCertificate=true;");

        return new SchoolContext(optionsBuilder.Options);
    }
}