using Testcontainers.PostgreSql;

namespace Agency.Test;

public sealed class SharedFixture : IAsyncLifetime
{

    private readonly PostgreSqlContainer _testcontainer;

    public SharedFixture()
    {
        _testcontainer = new PostgreSqlBuilder(Globals.PostgreSQLContainer)
            .WithDatabase("test")
            .WithUsername("uname")
            .WithPassword("password")
            .Build();
    }
    public Task DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public Task InitializeAsync()
    {
       return _testcontainer.StartAsync();
    }
}
