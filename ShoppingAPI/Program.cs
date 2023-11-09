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
builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "MyPolicy",
//        policy =>
//        {
//            policy.WithOrigins("http://example.com"

//                    //,"https://localhost:7046",
//                    //"https://localhost:5046"
//                    );

//                //WithOrigins("http://example.com")
//                //.WithMethods("GET", "POST")
//                //.WithHeaders("content-type", "accept");
//        });
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
    options.AddPolicy("CorsAllowSpecific",
        p => p.WithHeaders("Content-Type", "Accept", "Auth-Token")
            .WithMethods("POST", "PUT", "DELETE")
            .SetPreflightMaxAge(new TimeSpan(1728000))
            .AllowAnyOrigin()
            .AllowCredentials()
        );
});


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.UseCors(DefaultCorsPolicy);

var corsAllowAll = builder.Configuration["AppSettings:CorsAllowAll"] ?? "false";
app.UseCors(corsAllowAll == "true" ? "CorsAllowAll" : "CorsAllowSpecific");


app.UseAuthorization();

app.MapControllers();

app.Run();
