namespace QuitSmokingApi.Services;

using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.ApiModels;
using QuitSmokingApi.Data.Context;
using QuitSmokingApi.Data.Entities;

public interface ISmokeHistoryService
{
    public Task<IEnumerable<SmokeHistoryReadDto>> GetSmokeHistoriesAsync(int userId);
    public Task<IEnumerable<SmokeHistoryReadDto>> GetSmokeHistoriesByDateRangeAsync(int userId, DateOnly startDate, DateOnly endDate);
    public Task<SmokeHistoryReadDto> CreateSmokeHistoryAsync(SmokeHistoryCreateDto dto);
}

public class SmokeHistoryService : ISmokeHistoryService
{
    private readonly QuitSmokingDbContext dbContext;

    public SmokeHistoryService(QuitSmokingDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        this.dbContext = dbContext;
    }

    public async Task<SmokeHistoryReadDto> CreateSmokeHistoryAsync(SmokeHistoryCreateDto dto)
    {
        var shToCreate = dto.Adapt<SmokeHistory>();

        this.dbContext.SmokeHistory.Add(shToCreate);

        await this.dbContext.SaveChangesAsync();

        var shToReturn = shToCreate.Adapt<SmokeHistoryReadDto>();

        return shToReturn;
    }
    public async Task<IEnumerable<SmokeHistoryReadDto>> GetSmokeHistoriesAsync(int userId) => await this.dbContext.SmokeHistory.Where(h => h.UserId == userId).ProjectToType<SmokeHistoryReadDto>().ToListAsync();
    Task<IEnumerable<SmokeHistoryReadDto>> ISmokeHistoryService.GetSmokeHistoriesByDateRangeAsync(int userId, DateOnly startDate, DateOnly endDate) => throw new NotImplementedException();
}
