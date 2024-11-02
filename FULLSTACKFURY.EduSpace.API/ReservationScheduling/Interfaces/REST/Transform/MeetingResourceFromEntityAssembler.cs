using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Transform;

/// <summary>
/// Assembler class to transform Meeting to MeetingResource
/// </summary>
public class MeetingResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Meeting to MeetingResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Meeting"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="MeetingResource"/> resource with the values from the entity
    /// </returns>
    public static MeetingResource ToResourceFromEntity(Meeting entity)
    {
        return new MeetingResource(
            entity.MeetingId,
            entity.Title,
            entity.Description,
            entity.StartTime,
            entity.EndTime,
            entity.Date,
            entity.Invitees.Select(teacher => TeacherResourceFromEntityAssembler.ToResourceFromEntity(teacher)).ToList(),
            entity.Responsible.Select(administrator => AdministratorResourceFromEntityAssembler.ToResourceFromEntity(administrator)).ToList()
        );
    }
}