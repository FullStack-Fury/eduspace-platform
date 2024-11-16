using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;

public class MeetingResourceFromEntityAssembler
{
    public static MeetingResource ToResourceFromEntity(Meeting entity)
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