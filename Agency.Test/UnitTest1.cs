using Microsoft.EntityFrameworkCore;

namespace Agency.Test;

public class UnitTest1 : IClassFixture<SharedFixture>
{
    private readonly SharedFixture fixture;
    public UnitTest1(SharedFixture sharedFixture)
    {
        fixture = sharedFixture;
    }
    [Fact]
    public async Task Test1()
    {
        var context = fixture.Create();

        var items = await context.Agencies.ToListAsync(CancellationToken.None);
    }
}
