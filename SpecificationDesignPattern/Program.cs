using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Core.Entities;
using SpecificationPattern.Data;
//using SpecificationPattern.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SpecificationPatternDb;Trusted_Connection=True;MultipleActiveResultSets=true");
});

builder.Services.AddScoped<IGenericRepository<Developer>, GenericRepository<Developer>>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
