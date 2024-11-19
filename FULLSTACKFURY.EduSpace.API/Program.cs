using FULLSTACKFURY.EduSpace.API.EventsScheduling.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Application.Internal.OutboundServices;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.IAM.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.IAM.Application.Internal.OutboundServices;
using FULLSTACKFURY.EduSpace.API.IAM.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.IAM.Domain.Repository;
using FULLSTACKFURY.EduSpace.API.IAM.Domain.Services;
using FULLSTACKFURY.EduSpace.API.IAM.Interfaces.ACL;
using FULLSTACKFURY.EduSpace.API.IAM.Interfaces.ACL.Services;
using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.Pipeline.Middleware.Components;
using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.Toknes.JWT.Configuration;
using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.Toknes.JWT.Services;
using FULLSTACKFURY.EduSpace.API.Profiles.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.Profiles.Application.Internal.OutboundServices.ACL;
using FULLSTACKFURY.EduSpace.API.Profiles.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.ACL;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.ACL.Services;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.OutboundServices.ACL;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.ACL;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.ACL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IExternalProfileService = FULLSTACKFURY.EduSpace.API.EventsScheduling.Application.Internal.OutboundServices.IExternalProfileService;

var builder = WebApplication.CreateBuilder(args);

//Environment variables//

string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? "localhost";
string user = Environment.GetEnvironmentVariable("DB_USER") ?? "root";
string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "1234";
string database = Environment.GetEnvironmentVariable("DB_NAME") ?? "eduspace";

string connectionString = $"server={server};user={user};password={password};database={database}";

Console.WriteLine(connectionString);


// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder => policyBuilder
            .WithOrigins("http://localhost:5173") // Your frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "FullStackFury.EduSpacePlatform.API",
                Version = "v1",
                Description = "Eduspace Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Eduspace",
                    Email = "contact@fullstackfury.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token into field",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
        c.EnableAnnotations();
    });

builder.Configuration["ConnectionStrings.DefaultConnection"] = connectionString;

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string not found.");
}




builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {

        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

//Shared BC
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Profiles BC
builder.Services.AddScoped<IAdminProfileRepository, AdminProfileRepository>();
builder.Services.AddScoped<ITeacherProfileRepository, TeacherProfileRepository>();
builder.Services.AddScoped<IAdminProfileCommandService, AdminProfileCommandService>();
builder.Services.AddScoped<IAdminProfileQueryService, AdminProfileQueryService>();
// builder.Services.AddScoped<IAdminProfileQueryService, AdminProfileQueryService>();
builder.Services.AddScoped<ITeacherProfileCommandService, TeacherProfileCommandService>();
builder.Services.AddScoped<ITeacherQueryService, TeacherProfileQueryService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
builder.Services.AddScoped<IExternalIamService, ExternalIamService>();




builder.Services.AddScoped<IReservationCommandService, ReservationCommandService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IExternalProfileService, ExternalProfileServices>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();
builder.Services.AddScoped<IReservationQueryService, ReservationQueryService>();

//Reservation Scheduling

builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();
builder.Services.AddScoped<IMeetingCommandService, MeetingCommandService>();
builder.Services.AddScoped<IMeetingQueryService, MeetingQueryService>();
builder.Services.AddScoped<IExternalClassroomService, ExternalClassroomServices>();
builder.Services.AddScoped<IRExternalProfileService, RExternalProfileServices>();

// Spaces and Resource BC
// Classrooms
builder.Services.AddScoped<FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.OutboundServices.ACL.IExternalProfileService, ExternalProfileService>();
builder.Services.AddScoped<IClassroomRepository, ClassroomRepository>();
builder.Services.AddScoped<IClassroomCommandService, ClassroomCommandService>();
builder.Services.AddScoped<IClassroomQueryService, ClassroomQueryService>();
// Resources
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IResourceCommandService, ResourceCommandService>();
builder.Services.AddScoped<IResourceQueryService, ResourceQueryService>();

builder.Services.AddScoped<ISpacesAndResourceManagementFacade, SpacesAndResourceManagementFacade>();


// Shared Areas
builder.Services.AddScoped<ISharedAreaRepository, SharedAreaRepository>();
builder.Services.AddScoped<ISharedAreaCommandService, SharedAreaCommandService>();
builder.Services.AddScoped<ISharedAreaQueryService, SharedAreaQueryService>();

//Token Settings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountCommandService, AccountCommandService>();
builder.Services.AddScoped<IAccountQueryService, AccountQueryService>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseRouting();

// Use the CORS policy
app.UseCors("AllowFrontend");




app.UseAuthorization();



app.MapControllers();

app.Run();