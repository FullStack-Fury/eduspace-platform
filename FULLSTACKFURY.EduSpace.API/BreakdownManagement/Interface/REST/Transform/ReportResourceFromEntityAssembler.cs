namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Transform;

using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;

public static class ReportResourceFromEntityAssembler
{
    /// <summary>
    /// Transforms a Report entity into a ReportResource.
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Report"/> entity to transform.
    /// </param>
    /// <returns>
    /// The resulting <see cref="ReportResource"/> with values from the entity.
    /// </returns>
    public static ReportResource ToResourceFromEntity(Report entity)
    {
        return new ReportResource(
            entity.KindOfReport,         // KindOfReport as string
            entity.Description,          // Description as string
            entity.ResourceId.ToString(), // Convert ResourceId from int to string
            entity.CreatedAt,            // CreatedAt as DateTime
            entity.Status         // Status as string from Status value object
        );
    }
}