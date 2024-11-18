using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;

/// <summary>
/// Represents the report query service in the Report Management system.
/// </summary>
public interface IReportQueryService
{
    /// <summary>
    /// Handles the query to retrieve all reports.
    /// </summary>
    /// <param name="query">The <see cref="GetAllReportsQuery"/> to handle.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of all reports.
    /// </returns>
    Task<IEnumerable<Report>> HandleAllReportsQuery(GetAllReportsQuery query);

    /// <summary>
    /// Handles the query to retrieve a single report entry by its unique identifier.
    /// </summary>
    /// <param name="query">The <see cref="GetReportByIdQuery"/> containing the report ID.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the report entry if found; otherwise, null.
    /// </returns>
    Task<Report?> HandleReportByIdQuery(GetReportByIdQuery query);

    /// <summary>
    /// Handles the query to retrieve all reports for a specific resource.
    /// </summary>
    /// <param name="query">The <see cref="GetReportByResourceIdQuery"/> containing the resource ID.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of reports associated with the specified resource.
    /// </returns>
    Task<IEnumerable<Report>> HandleReportsByResourceIdQuery(GetReportByResourceIdQuery query);
    
    /// <summary>
    /// Handles the query to retrieve all payroll entries for a specific teacher.
    /// </summary>
    /// <param name="query">The <see cref="GetReportByTeacherIdQuery"/> containing the teacher ID.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of payroll entries associated with the specified teacher.
    /// </returns>
    Task<IEnumerable<Report>> Handle(GetReportByTeacherIdQuery query);
}