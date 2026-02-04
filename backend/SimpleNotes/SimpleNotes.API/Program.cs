using Microsoft.EntityFrameworkCore;
using SimpleNotes.Application.Interfaces.Repositories;
using SimpleNotes.Application.Interfaces.Services;
using SimpleNotes.Application.Services;
using SimpleNotes.Infrastructure.Persistance;
using SimpleNotes.Infrastructure.Repositories;
using Scalar.AspNetCore; // sadece UI için namespace

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// OpenAPI generator (Microsoft.AspNetCore.OpenApi)
builder.Services.AddOpenApi(); // minimal OpenAPI generator

// DbContext (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterWeb",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    // OpenAPI document endpoint
    app.MapOpenApi();

    // Scalar UI endpoint
    app.MapScalarApiReference();
}

app.UseCors("AllowFlutterWeb");
app.UseAuthorization();
app.MapControllers();

app.Run();
