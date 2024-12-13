using Microsoft.EntityFrameworkCore;
using WebAPIEstatusAlumnos.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("InstitutoTich");
builder.Services.AddDbContext<TichContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => { options.AddPolicy("AllowTodito", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); });

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowTodito");

app.UseAuthorization();

app.MapControllers();

app.Run();
