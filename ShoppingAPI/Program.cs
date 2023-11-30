using Microsoft.EntityFrameworkCore;
using ShoppingAPI.BaseParameters;
using ShoppingAPI.Models;
using ShoppingAPI.Repository;
using ShoppingAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddJsonOptions(options =>
      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MyServices

builder.Services.AddDbContext<MyContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnectionString")));
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ISliderParameters, SliderParameters>();
builder.Services.AddScoped<ISliderGalleryRepository, SliderGalleryRepository>();
builder.Services.AddScoped<ISliderGalleryService, SliderGalleryService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddCors(b => b.AddPolicy("MyPolicy", options =>
//options.WithOrigins("https://google.com", "https://localhost:7111", "http://localhost:5111")
//.WithMethods("GET", "POST")));


builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
{
    builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("*")
        .AllowCredentials()
        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
        .SetIsOriginAllowed(origin => _ = true);
}));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("MyPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
