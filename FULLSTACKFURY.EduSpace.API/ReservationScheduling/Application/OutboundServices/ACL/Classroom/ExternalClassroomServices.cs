using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.ACL;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public class ExternalClassroomServices(ISpacesAndResourceManagementFacade spacesFacade) : IExternalClassroomService
{
    public bool VerifyClassroom(int classroomId)
    {
        return spacesFacade.ValidateClassroomIdExistence(classroomId);
    }
}