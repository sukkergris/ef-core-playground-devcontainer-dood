using Testcontainers.PostgreSql;

namespace Agency.Test;

public sealed class PostgreSQLTests : IAsyncLifetime
{
    private readonly PostgreSqlContainer _testcontainer;
    internal string ConnectionString { get; private set; } = "unset";

    public PostgreSQLTests()
    {
        _testcontainer = new PostgreSqlBuilder(Globals.PostgreSQLContainer)
            .WithDatabase("test")
            .WithUsername("uname")
            .WithPassword("password")
            .Build();
    }
    public async Task InitializeAsync()
    {

        await _testcontainer.StartAsync();
        ConnectionString = _testcontainer.GetConnectionString();
    }

    Task IAsyncLifetime.DisposeAsync()
    {
        return _testcontainer.DisposeAsync().AsTask();
    }

    public sealed class Double0RangeTests : IClassFixture<PostgreSQLTests>, IDisposable
    {
        public Double0RangeTests(PostgreSQLTests fixture)
        {
            
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
