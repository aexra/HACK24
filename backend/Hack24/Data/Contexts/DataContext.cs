using Microsoft.EntityFrameworkCore;

namespace Web.Data.Contexts;

public class DataContext : DbContext
{
    public string DbPath { get; }

    public DataContext()
    {
        DbPath = "Data/Databases/Data.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
