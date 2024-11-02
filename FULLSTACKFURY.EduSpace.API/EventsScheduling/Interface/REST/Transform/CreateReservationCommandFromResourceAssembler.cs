using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Interface.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Interface.REST.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource)
    {
        return new CreateReservationCommand(resource.Title
            , resource.Start, resource.End
            , resource.AreaId, resource.TeacherId);
    }

}