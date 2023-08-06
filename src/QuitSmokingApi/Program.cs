using Microsoft.EntityFrameworkCore;
using QuitSmokingApi.Data.Context;
using QuitSmokingApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuitSmokingDbContext>(o => o.UseInMemoryDatabase("test"));
builder.Services.AddScoped<ISmokeHistoryService, SmokeHistoryService>();


var app = builder.Build();

app.MapGet("/", async (ISmokeHistoryService smokeHistoryService) => await smokeHistoryService.GetSmokeHistories());

app.Run();
