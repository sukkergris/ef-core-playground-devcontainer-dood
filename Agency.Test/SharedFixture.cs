using Agency;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Agency.Test;

public sealed class SharedFixture : IAsyncLifetime
{

    private readonly PostgreSqlContainer _testcontainer;
    public string ConnectionString { get; private set; } = string.Empty;

    public SharedFixture()
    {
        _testcontainer = new PostgreSqlBuilder(Globals.PostgreSQLContainer)
            .WithDatabase("test")
            .WithUsername("uname")
            .WithPassword("password")
            .Build();
    }
    public Task DisposeAsync() =>
        _testcontainer.DisposeAsync().AsTask();

    public async Task InitializeAsync()
    {
        await _testcontainer.StartAsync();
        ConnectionString = _testcontainer.GetConnectionString();

        await using var context = Create();
        await context.Database.MigrateAsync();
    }

    public AgencyDbContext Create()
    {
        if (string.IsNullOrWhiteSpace(ConnectionString)) throw new ArgumentNullException(nameof(ConnectionString));

        DbContextOptionsBuilder<AgencyDbContext> optionsBuilder = new();
        var options = Base.DbContextHelpers.GetDbContextOptions(
            optionsBuilder,
            ConnectionString,
             Agency.Globals.AgencyDefaultSchema);

        return new AgencyDbContext(options.Options);
    }
}
