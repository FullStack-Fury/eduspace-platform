using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;

public interface IReportCommandService
{
    // Maneja el comando para crear un informe
    Task<Report> Handle(CreateReportCommand command);

    // Maneja el comando para eliminar un informe
    Task<bool> Handle(DeleteReportCommand command);
    Task<Report> Handle(UpdateReportCommand command);
}