using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public class ExternalClassroomServices(IClassroomContext context) : IExternalClassroomService
{
    public bool ValidateClassroomName(string name)
    {
        return context.ValidateClassroomNameExists(name); 
    }
}