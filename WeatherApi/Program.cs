using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.NetworkInformation;
using WeatherApi.Data;
using WeatherApi.Models;
using Microsoft.Extensions.Configuration;
using WeatherApi.Repo;
using WeatherApi.Middlware;
using WeatherApi.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers(options => {  options.Filters.Add(new WeatherApi.Filters.ExceptionFilterAttribute()); });
//builder.Services.AddControllers();
//builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("* *"
                                              );
                      });
});




//builder.Services.AddTransient<ControllerMiddleware>(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<InformationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepo, InformationConnection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(MyAllowSpecificOrigins);
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());
app.UseHttpsRedirection();

//app.UseMiddleware<ControllerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
