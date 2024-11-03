using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.ACL;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public class ExternalProfileServices(IProfilesContextFacade contextFacade) : IExternalProfileService
{
    public bool ValidateTeacherIdExistence(int teacherId)
    {
        return contextFacade.ValidateTeacherProfileIdExistence(teacherId);
    }
    
    public bool ValidateAdminIdExistence(int adminid)
    {
        return contextFacade.ValidateAdminProfileIdExistence(adminid);
    }
}