namespace QuitSmokingApi.Services;
using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.Data.Context;
using QuitSmokingApi.Data.Entities;

public interface ISmokeHistoryService
{
    public Task<IEnumerable<SmokeHistory>> GetSmokeHistories();
}

public class SmokeHistoryService : ISmokeHistoryService
{
    private readonly QuitSmokingDbContext dbContext;

    public SmokeHistoryService(QuitSmokingDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<SmokeHistory>> GetSmokeHistories() => await this.dbContext.SmokeHistory.ToListAsync();
}
