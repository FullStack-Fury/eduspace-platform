namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects
{
    public record ReportDate
    {
        public DateTime CreatedAt { get; init; }

        public ReportDate(DateTime createdAt)
        {
            if (createdAt > DateTime.Now) 
                throw new ArgumentException("The creation date cannot be in the future.");
            
            CreatedAt = createdAt;
        }
    }
}
