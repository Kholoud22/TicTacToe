using Serilog;
using System.Text.Json.Serialization;
using TicTacToe.API;
using TicTacToe.Application;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using TicTacToe.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(Logger.ConfigureLogger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();

builder.Services.AddCors();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(new List<Assembly>() { typeof(ApplicationLayer).Assembly });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
        options => options.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
