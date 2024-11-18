using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates
{
    public class Report
    {
        public int Id { get; private set; }
        public int TeacherId { get; private set; }
        public int ResourceId { get; private set; }
        public string KindOfReport { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Usamos un simple string para el estado
        public string Status { get; private set; }

        public Report() { }

        public Report(CreateReportCommand command)
        {
            TeacherId = command.TeacherId;
            ResourceId = command.ResourceId;
            KindOfReport = command.KindOfReport;
            Description = command.Description;
            CreatedAt = command.CreatedAt;
            Status = command.Status ?? "Pendiente";  // Estado por defecto si es nulo
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }
    }

}