namespace Infrastructure.EntityFramework;

public sealed class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var host = Path.Exists("/.dockerenv") ? "database" : "localhost";
        var connection = new NpgsqlConnection($"User ID=postgres;Password=local;Host={host};Port=5432;Database=postgres");

        connection.Open();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(connection);

        return new ApplicationContext(optionsBuilder.Options);
    }
}