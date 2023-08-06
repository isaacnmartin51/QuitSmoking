using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.ApiModels;
using QuitSmokingApi.Data.Context;
using QuitSmokingApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuitSmokingDbContext>(o => o.UseInMemoryDatabase("test"));
builder.Services.AddScoped<ISmokeHistoryService, SmokeHistoryService>();
builder.Services.AddScoped<IMapper, Mapper>();


var app = builder.Build();

app.MapGet("SmokeHistory/{UserId}", async (int userId, ISmokeHistoryService smokeHistoryService) => await smokeHistoryService.GetSmokeHistoriesAsync(userId));
app.MapPost("SmokeHistory/{SmokeHistoryCreateDto}", async (SmokeHistoryCreateDto dto, ISmokeHistoryService smokeHistoryService) => await smokeHistoryService.CreateSmokeHistoryAsync(dto));

app.Run();
