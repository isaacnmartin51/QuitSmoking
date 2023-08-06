namespace QuitSmokingApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.Data.Entities;

public class QuitSmokingDbContext : DbContext
{
    public DbSet<SmokeHistory> SmokeHistory { get; set; }

    public QuitSmokingDbContext(DbContextOptions<QuitSmokingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SmokeHistory>().HasData(
            new SmokeHistory() { SmokeHistoryId = 1, SmokedDate = DateTime.Now },
            new SmokeHistory() { SmokeHistoryId = 2, SmokedDate = DateTime.Now.AddDays(-1) },
            new SmokeHistory() { SmokeHistoryId = 3, SmokedDate = DateTime.Now.AddDays(-2) }
        );
        base.OnModelCreating(modelBuilder);
    }
}

