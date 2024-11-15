namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands
{
    /// <summary>
    /// Command to update the status of a report.
    /// </summary>
    public record UpdateReportCommand
    {
        /// <summary>
        /// The unique identifier of the report to be updated.
        /// </summary>
        public int ReportId { get; init; }

        /// <summary>
        /// The new status of the report.
        /// </summary>
        public string Status { get; init; }

        /// <summary>
        /// Initializes a new instance of the UpdateReportCommand.
        /// </summary>
        /// <param name="reportId">The unique identifier of the report.</param>
        /// <param name="status">The new status for the report.</param>
        public UpdateReportCommand(int reportId, string status)
        {
            ReportId = reportId;
            Status = status;
        }
    }
}