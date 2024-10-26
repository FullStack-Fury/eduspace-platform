using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates
{
    public class Report
    {
        public int Id { get; private set; }
        public string KindOfReport { get; private set; }
        public string Description { get; private set; }
        public ResourceId ResourceId { get; private set; }
        public ReportDate CreatedAt { get; private set; }

        // Constructor sin parámetros para EF Core
        private Report() { }

        public Report(string kindOfReport, string description, ResourceId resourceId, ReportDate createdAt)
        {
            KindOfReport = kindOfReport;
            Description = description;
            ResourceId = resourceId;
            CreatedAt = createdAt;
        }

        public void UpdateReport(string kindOfReport, string description, ResourceId resourceId)
        {
            KindOfReport = kindOfReport;
            Description = description;
            ResourceId = resourceId;
        }
    }
}