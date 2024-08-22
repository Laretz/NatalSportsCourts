using Microsoft.EntityFrameworkCore;
using QuadrasNatal.API.ExceptionHandler;
using QuadrasNatal.Application;
using QuadrasNatal.API.Services;
using QuadrasNatal.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IConfigService, ConfigService>();

//builder.Services.AddDbContext<QuadrasNatalDbContext>(o => o.UseInMemoryDatabase("QuadrasNatalDb"));
var connectionString = builder.Configuration.GetConnectionString("QuadraNatalCs");
builder.Services.AddDbContext<QuadrasNatalDbContext>(o => o.UseSqlServer(connectionString));

builder.Services
    .AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
