using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RazorPages9Demo.Infrastructure.Postgres;

// ReSharper disable once UnusedType.Global
// Required to run EF migrations. NOTE: PostgresConnection string must be defined in user secrets.
public class PostgresContextFactory : IDesignTimeDbContextFactory<PostgresContext>
{
    public PostgresContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<PostgresContextFactory>() // Reads from this project's user secrets
            .Build();

        var configuration = configurationBuilder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
        optionsBuilder.UseNpgsql(
            configuration.GetConnectionString("PostgresConnection")
            ?? throw new InvalidOperationException("Connection string 'PostgresConnection' not found."));

        return new PostgresContext(optionsBuilder.Options);
    }
}