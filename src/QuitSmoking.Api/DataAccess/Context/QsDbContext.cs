namespace QuitSmoking.Api.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Api.DataAccess.Entities;

public class QsDbContext : DbContext
{
    public DbSet<CigaretteSmoked> CigarettesSmoked { get; set; }
    public QsDbContext(DbContextOptions<QsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CigaretteSmoked>()
            .Property(c => c.CreateDate)
            .HasDefaultValue(DateTime.Now);


    }
}