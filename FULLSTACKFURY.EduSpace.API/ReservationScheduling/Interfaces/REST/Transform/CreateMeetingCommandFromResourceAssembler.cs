using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;

public class CreateMeetingCommandFromResourceAssembler
{
    public static CreateMeetingCommand ToCommandFromResource(CreateMeetingResource resource)
    {
        return new CreateMeetingCommand(
            resource.Title,
            resource.Description,
            resource.Start,
            resource.End,
            resource.Date,
            resource.TeacherId,
            resource.AdminId);
    }
}