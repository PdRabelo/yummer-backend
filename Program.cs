using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using yummer_backend;
using yummer_backend.Data;
using yummer_backend.Models;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(conn));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMyServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

//app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();