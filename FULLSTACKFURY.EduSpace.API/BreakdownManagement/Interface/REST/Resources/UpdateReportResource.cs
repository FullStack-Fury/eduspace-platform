namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;

using System;

/// <summary>
/// Represents a resource to update the status of a report.
/// </summary>
/// <param name="Status">
/// The current status of the report (e.g., Pending, Processed, Completed).
/// </param>
public record UpdateReportResource(
    
    string Status
);