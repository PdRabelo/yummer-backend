using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using yummer_backend.Data;
using yummer_backend.Models;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(conn));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMyServices();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder();

// Add Identity services
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApiDbContext>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();