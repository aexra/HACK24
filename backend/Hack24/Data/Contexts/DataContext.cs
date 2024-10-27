using Microsoft.EntityFrameworkCore;

namespace Hack24.Data.Contexts;

public class DataContext : DbContext
{
    public string DbPath { get; }

    public DataContext()
    {
        DbPath = "Data/Databases/Data.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=oggentoData;Username=postgres;Password=1234");
}
