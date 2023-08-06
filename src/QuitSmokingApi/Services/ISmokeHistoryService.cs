using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.Data.Context;
using QuitSmokingApi.Data.Entities;

namespace QuitSmokingApi.Services;

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
    public async Task<IEnumerable<SmokeHistory>> GetSmokeHistories()
    {
        return await dbContext.SmokeHistory.ToListAsync();
    }
}
