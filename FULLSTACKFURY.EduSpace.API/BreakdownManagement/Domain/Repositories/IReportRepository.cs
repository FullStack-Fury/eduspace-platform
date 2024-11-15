using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Repositories;

/// <summary>
/// Represents the report repository in the Report Management system.
/// </summary>
public interface IReportRepository : IBaseRepository<Report>
{
    /// <summary>
    /// Retrieves a report entry by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the report entry.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the report entry if found; otherwise, null.
    /// </returns>
    Task<Report?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all reports associated with a specific resource ID.
    /// </summary>
    /// <param name="resourceId">The unique identifier of the resource.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of reports for the specified resource.
    /// </returns>
    Task<IEnumerable<Report>> FindAllByResourceIdAsync(int resourceId);

    /// <summary>
    /// Deletes a report entry from the system.
    /// </summary>
    /// <param name="report">The report to be deleted.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task DeleteAsync(Report report); // Agregamos el método DeleteAsync
    
    Task UpdateAsync(Report report); 
}