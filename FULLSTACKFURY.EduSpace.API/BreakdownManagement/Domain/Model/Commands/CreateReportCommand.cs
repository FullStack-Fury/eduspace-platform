using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands
{
    public record CreateReportCommand
    {
        public int TeacherId { get; }
        public int ResourceId { get; }
        public string KindOfReport { get; }
        public string Description { get; }
        public string Status { get; } // Cambiado a Status
        public DateTime CreatedAt { get; }

        public CreateReportCommand(int teacherId, int resourceId, string kindOfReport, string description, string status, DateTime createdAt)
        {
            TeacherId = teacherId;
            ResourceId = resourceId;
            KindOfReport = kindOfReport;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}