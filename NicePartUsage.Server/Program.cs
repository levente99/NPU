using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NicePartUsage.Application;
using NicePartUsage.Application.Interfaces;
using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Application.Interfaces.Services;
using NicePartUsage.Application.Repositories;
using NicePartUsage.Application.Services;
using NicePartUsage.Domain.Models;
using NicePartUsage.Infrastructure;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Value;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddMvc().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<NicePartUsageDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<NicePartUsageDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();

builder.Services.AddControllers();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IElementRepository, ElementRepository>();
builder.Services.AddTransient<INpuCreationRepository, NpuCreationRepository>();
builder.Services.AddTransient<IScoreRepository, ScoreRepository>();
builder.Services.AddTransient<IElementService, ElementService>();
builder.Services.AddTransient<INpuCreationService, NpuCreationService>();
builder.Services.AddTransient<IScoreService, ScoreService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.MapIdentityApi<User>();

app.Run();
