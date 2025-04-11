
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Repositories.Interfaces;
using backend.Repositories;
using Microsoft.AspNetCore.Builder;
using backend.Services;



var builder = WebApplication.CreateBuilder(args);

// ✅ add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//Authentication google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "Google";
})
.AddCookie("Cookies")
.AddGoogle("Google", options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
});

// ✅ Swagger/OpenAPI setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<JwtTokenService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables();


// CORS
app.UseCors("AllowFrontend");

// Authentication
app.UseAuthentication();
app.UseAuthorization();

// HTTPS
app.UseHttpsRedirection();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Controller
app.MapControllers();


app.Run();
