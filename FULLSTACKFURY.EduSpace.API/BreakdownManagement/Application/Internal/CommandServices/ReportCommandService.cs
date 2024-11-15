using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Application.Internal.CommandServices;

/// <summary>
/// Represents a command service for managing report entities.
/// </summary>
public class ReportCommandService : IReportCommandService
{
    private readonly IReportRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportCommandService"/> class.
    /// </summary>
    /// <param name="repository">The report repository instance.</param>
    /// <param name="unitOfWork">The unit of work for transaction management.</param>
    public ReportCommandService(IReportRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Handles the creation of a new report entry.
    /// </summary>
    /// <param name="command">The <see cref="CreateReportCommand"/> containing report details.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the created report entry.
    /// </returns>
    public async Task<Report> Handle(CreateReportCommand command)
    {
        var report = new Report(command); // Crea un nuevo objeto de Report usando el comando
        await _repository.AddAsync(report); // Agrega el informe al repositorio
        await _unitOfWork.CompleteAsync(); // Completa la transacción
        return report; // Devuelve el informe creado
    }

    /// <summary>
    /// Handles the deletion of a report entry.
    /// </summary>
    /// <param name="command">The <see cref="DeleteReportCommand"/> containing the ID of the report to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    public async Task<bool> Handle(DeleteReportCommand command)
    {
        var report = await _repository.GetByIdAsync(command.ReportId); // Recupera el informe por su ID

        if (report == null) 
        {
            // Si no se encuentra el informe, devuelve false
            return false;
        }

        await _repository.DeleteAsync(report); // Elimina el informe
        await _unitOfWork.CompleteAsync(); // Completa la transacción

        return true;  // La eliminación fue exitosa
    }

    /// <summary>
    /// Handles the update of an existing report entry.
    /// </summary>
    /// <param name="command">The <see cref="UpdateReportCommand"/> containing report update details.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the updated report entry.
    /// </returns>
    public async Task<Report> Handle(UpdateReportCommand command)
    {
        // Recuperar el reporte desde el repositorio
        var report = await _repository.GetByIdAsync(command.ReportId);

        if (report == null) 
        {
            throw new Exception($"Report with ID {command.ReportId} not found");
        }

        // Ahora simplemente usamos el string del comando para actualizar el status
        var newStatus = command.Status;  // Esto es solo un string

        // Actualizar el estado usando el método UpdateStatus
        report.UpdateStatus(newStatus);  // Ahora pasamos el string directamente

        // Guardar los cambios
        await _repository.UpdateAsync(report);
        await _unitOfWork.CompleteAsync();

        return report;
    }


}
