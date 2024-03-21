using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using TestTaskFeedbackFormST.Server.DataContext;
using TestTaskFeedbackFormST.Server.Services;
using TestTaskFeedbackFormST.Server.Repositories;
using static System.Console;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbOfUserRequestsContext>(s=>s.UseSqlServer("Name=ConnectionStrings:DefaultConnection"));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IdirectoryOfMessageTopicsService, DirectoryOfMessageTopicsService>();
builder.Services.AddTransient<ImessageService, MessageService>();
builder.Services.AddTransient<IñontactRepository, ContactRepository>();
builder.Services.AddTransient<ImessageRepository, MessageRepository>();
builder.Services.AddTransient<IdirectoryOfMessageTopicRepository, DirectoryOfMessageTopicRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader()
                            .AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
