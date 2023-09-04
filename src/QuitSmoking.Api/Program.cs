using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuitSmoking.Api.DataAccess.Context;
using QuitSmoking.Api.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QsDbContext>(o => 
{
    o.UseInMemoryDatabase("qs");
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer();


var app = builder.Build();

app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret").RequireAuthorization();

app.MapPost("/Activity", async ([FromBody] LogSmokeActivityRequest request, QsDbContext _context) => {

    var smokeActivity = new CigaretteSmoked() {
        DateSmoked = request.DateSmoked
    };

    await _context.AddAsync(smokeActivity);
    await _context.SaveChangesAsync();
});

app.MapGet("/Activity",async (QsDbContext _context) => {
    return await _context.CigarettesSmoked.ToListAsync();
});


app.Run();

public record LogSmokeActivityRequest(DateTime DateSmoked, Guid SmokedBy);