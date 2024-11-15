namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources
{
    /// <summary>
    /// Represents a report resource.
    /// </summary>
    /// <param name="ResourceId">
    /// The unique identifier for the resource associated with this report.
    /// </param>
    /// <param name="KindOfReport">
    /// The type of the report (e.g., breakdown, performance, etc.).
    /// </param>
    /// <param name="Description">
    /// A detailed description of the report.
    /// </param>
    /// <param name="Status">
    /// The current status of the report (e.g., Pending, Process, Finished).
    /// </param>
    /// <param name="CreatedAt">
    /// The date and time when the report was created.
    /// </param>
    public record CreateReportResource(
        int ResourceId,
        string KindOfReport,
        string Description,
        string Status,
        DateTime CreatedAt
    );
    
}