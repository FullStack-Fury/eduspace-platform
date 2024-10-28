using FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.QueryServices;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Application.Internal.CommandServices;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.PayrollManagement.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendLocalhost",
        policy => policy.WithOrigins("http://localhost:5174", "https://localhost:5174") // Agrega ambas versiones
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Agregar servicios a la aplicación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(); // Agregar servicio de autorización

// Configurar la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not set.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
        .EnableDetailedErrors();
});

// Registrar los servicios de consultas y comandos para Teacher y Payroll
builder.Services.AddScoped<TeacherQueryService>();
builder.Services.AddScoped<IPayrollCommandService, PayrollCommandService>();

// Registrar el repositorio de Payroll y el UnitOfWork
builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Registrar el IUnitOfWork con su implementación concreta

var app = builder.Build();

// Verificar y crear la base de datos si no existe
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    try
    {
        // Verificar y crear tablas si no existen
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear la base de datos: {ex.Message}");
        throw;
    }
}

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar la política de CORS configurada
app.UseCors("AllowFrontendLocalhost");

app.UseHttpsRedirection();
app.UseAuthorization(); // Llamada a autorización ahora es válida

// Definir el endpoint para obtener los profesores sin el prefijo '/api'
app.MapGet("/teachers", async (TeacherQueryService teacherService) =>
{
    var teachers = await teacherService.GetAllTeachers();
    return Results.Ok(teachers);
});

// Definir el endpoint para crear un payroll sin el prefijo '/api' utilizando el comando correspondiente
app.MapPost("/payroll", async (CreatePayrollCommand command, IPayrollCommandService payrollService) =>
{
    var result = await payrollService.Handle(command);
    if (result != null)
    {
        return Results.Created($"/payroll/{result.Id}", result);
    }
    return Results.BadRequest("Error al crear el payroll");
});



app.Run();
