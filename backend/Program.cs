
using backend.Data;
using Microsoft.EntityFrameworkCore;
using backend.Repositories.Interfaces;
using backend.Repositories;
using Microsoft.AspNetCore.Builder;


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


// ✅ Swagger/OpenAPI setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// ✅ Swagger activate
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// HTTPS redirection
app.UseHttpsRedirection();


// ✅ CORS applied
app.UseCors("AllowFrontend");

app.MapControllers(); // ✅ Map controllers


app.Run();
