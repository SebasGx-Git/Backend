using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Persistence.Repositories;
using PeruStar.API.PeruStar.Services;
using PeruStar.API.Security.Authorization.Handlers.Implementations;
using PeruStar.API.Security.Authorization.Handlers.Interfaces;
using PeruStar.API.Security.Authorization.Middleware;
using PeruStar.API.Security.Domain.Repositories;
using PeruStar.API.Security.Domain.Services;
using PeruStar.API.Security.Persistence.Repositories;
using PeruStar.API.Security.Services;
using PeruStar.API.Shared.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
//Sebas estuvo aqui xdxdxdxd
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// OpenAPI Configuration

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
    Version = "v1",
    Title = "PeruStar API",
    Description = "PeruStar Web Service",
    Contact = new OpenApiContact
    {
        Name = "PeruStar",
        Url = new Uri("https://perustar.pe")
    },
    License = new OpenApiLicense
    {
        Name = "PeruStar Center Resource License",
        Url = new Uri("https://perustar.pe/license")
    }
    });
    options.EnableAnnotations();
});


//Add lower case routing

builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Dependency Injection Configuration

//Shared injection configuration

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//PeruStar injection configuration
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IArtworkRepository, ArtworkRepository>();
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IClaimTicketRepository, ClaimTicketRepository>();
builder.Services.AddScoped<IClaimTicketService, ClaimTicketService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventAssistanceRepository, EventAssistanceRepository>();
builder.Services.AddScoped<IEventAssistanceService, EventAssistanceService>();
builder.Services.AddScoped<IFavoriteArtworkRepository, FavoriteArtworkRepository>();
builder.Services.AddScoped<IFavoriteArtworkService, FavoriteArtworkService>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHobbyistRepository, HobbyistRepository>();
builder.Services.AddScoped<IHobbyistService, HobbyistService>();

//Security injection configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();

//Auto Mapper Configuration
builder.Services.AddAutoMapper(
    typeof(PeruStar.API.PeruStar.Mapping.ModelToResourceProfile), 
    typeof(PeruStar.API.PeruStar.Mapping.ResourceToModelProfile),
    typeof(PeruStar.API.Security.Mapping.ModelToResourceProfile),
    typeof(PeruStar.API.Security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Creating database of entities

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context!.Database.EnsureCreated();
}

// Run the application for Swagger
//if (app.Environment.IsDevelopment()) 
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

// Configure CORS
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling

app.UseMiddleware<JwtMiddleware>();

// Run the application

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();