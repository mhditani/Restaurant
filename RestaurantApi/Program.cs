using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Restaurant.Entities.Data;
using Restaurant.Services.IRepositories;
using Restaurant.Services.Mapping;
using Restaurant.Services.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();

// ✅ Add Swagger + API Explorer
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });

// ✅ Add JWT Authentication to Swagger
//    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        BearerFormat = "JWT",
//        Description = "Enter 'Bearer {your JWT token}'"
//    });

//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = JwtBearerDefaults.AuthenticationScheme
//                }
//            },
//            Array.Empty<string>()
//        }
//    });
//});

// Add Database
builder.Services.AddDbContext<RestaurantDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantConnectionString"));
    });

    // Add AutoMapper
    builder.Services.AddAutoMapper(typeof(MapperClass));

    // Add Repositories
    builder.Services.AddScoped<IMenuRepo, MenuRepo>();
    builder.Services.AddScoped<IOrderRepo, OrderRepo>();
    builder.Services.AddScoped<ITokenRepo, TokenRepo>();

    // Add Identity
    builder.Services.AddIdentityCore<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<RestaurantDbContext>()
        .AddDefaultTokenProviders();

    // Identity password options
    builder.Services.Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequiredLength = 6;
        opt.Password.RequiredUniqueChars = 1;
    });

    // Add Authentication - JWT
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    //{
    //    app.UseSwagger();
    //    app.UseSwaggerUI(options =>
    //    {
    //        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
    //    });
    //}
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1S");
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
;