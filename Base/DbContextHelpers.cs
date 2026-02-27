using Microsoft.EntityFrameworkCore;

namespace Base;

public static class DbContextHelpers
{
    public static DbContextOptionsBuilder<T> GetDbContextOptions<T>(
        DbContextOptionsBuilder<T> builder,
        string connectionString,
        string schemaName) where T : DbContext
    {
         return builder
            // .AddInterceptors(new MyInterceptor())
            // .UseSnakeCaseNamingConvention()
            .UseNpgsql(
                connectionString, x => x.MigrationsHistoryTable(
                    "__ef_migrations_history", schemaName));
    }
}
