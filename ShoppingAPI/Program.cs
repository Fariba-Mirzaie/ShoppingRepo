using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Models;
using ShoppingAPI.Repository;
using ShoppingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MyServices
builder.Services.AddDbContext<MyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyCS")));
builder.Services.AddScoped<ISliderRepository, SliderService>();

#endregion

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
