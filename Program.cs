using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using WebApplication1;
using System.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

// 2.1. CORS
//builder.Services.AddCors(options =>
//{
//    string[] methods = { "GET", "POST", "PUT", "DELETE", "PATCH", "OPTIONS" };
//    options.AddPolicy("AllowFrontend", builder => builder.WithOrigins("*").AllowAnyHeader().WithMethods(methods));
//});


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure your dependencies here
var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
// Register DataAccessLayer
builder.Services.AddScoped<DataAccessLayer>();


// ...

var app = builder.Build();



// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

