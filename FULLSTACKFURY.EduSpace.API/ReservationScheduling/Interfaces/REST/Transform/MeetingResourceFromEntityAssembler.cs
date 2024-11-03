

using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to transform Meeting to MeetingResource
/// </summary>
public class MeetingResourceFromEntityAssembler
{
    public static MeetingResource FromEntity(Meeting entity)
    {
        return new MeetingResource(
            entity.MeetingId,
            entity.Title,
            entity.Description,
            entity.MeetingDate.Start,
            entity.MeetingDate.End,
            entity.Date);
    }
}