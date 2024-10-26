namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands
{
    public class CreateReportCommand
    {
        public string KindOfReport { get; }
        public string Description { get; }
        public int ResourceId { get; }
        public DateTime CreatedAt { get; }

        public CreateReportCommand(string kindOfReport, string description, int resourceId, DateTime createdAt)
        {
            KindOfReport = kindOfReport;
            Description = description;
            ResourceId = resourceId;
            CreatedAt = createdAt;
        }
    }
}