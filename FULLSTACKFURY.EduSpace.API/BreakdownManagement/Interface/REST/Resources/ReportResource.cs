namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;

using System;

/// <summary>
/// Represents a report resource.
/// </summary>
/// <param name="KindOfReport">
/// The type or category of the report (e.g., financial, technical).
/// </param>
/// <param name="Description">
/// A brief description or details of the report.
/// </param>
/// <param name="ResourceId">
/// The unique identifier for the resource associated with the report.
/// </param>
/// <param name="CreatedAt">
/// The date and time when the report was created.
/// </param>
/// <param name="Status">
/// The current status of the report (e.g., Pending, Processed, Completed).
/// </param>
public record ReportResource(
    long Id,
    string TeacherId,
    string KindOfReport,
    string Description,
    string ResourceId,
    DateTime CreatedAt,
    string Status
);