using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Entities.Data;
using Restaurant.Services.IRepositories;
using Restaurant.Services.Mapping;
using Restaurant.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Database
builder.Services.AddDbContext<RestaurantDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantConnectionString"));
});

// inject AutoMapper
builder.Services.AddAutoMapper(typeof(MapperClass));



// inject Repositories
builder.Services.AddScoped<IMenuRepo, MenuRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1S");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
