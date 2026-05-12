using Microsoft.EntityFrameworkCore;
using MusicPianoBusinessLogic;
using MusicPianoData;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PianoLessonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PianoDatabase")));
builder.Services.AddScoped<Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.Map("/api/Test", () => { return "Hello World!"; });

app.Run();
