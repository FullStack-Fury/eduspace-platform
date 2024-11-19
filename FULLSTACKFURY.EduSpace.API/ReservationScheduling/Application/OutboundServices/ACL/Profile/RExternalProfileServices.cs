using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.ACL;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public class RExternalProfileServices(IProfilesContextFacade profilesContextFacade) : IRExternalProfileService
{
    public bool VerifyProfile(int adminProfileId)
    {
        return profilesContextFacade.ValidateAdminProfileIdExistence(adminProfileId);
    }

    public bool ValidateTeacherExistence(int teacherId)  
    {
        return profilesContextFacade.ValidateTeacherProfileIdExistence(teacherId);  
    }
    
    public bool ValidateAdminIdExistence(int adminid)
    {
        return profilesContextFacade.ValidateAdminProfileIdExistence(adminid);
    }
    
    public bool ValidateTeachersExistence(List<int> teacherIds)
    {
        foreach (var teacherId in teacherIds)
        {
            if (!ValidateTeacherExistence(teacherId))
            {
                return false; 
            }
        }
        return true; 
    }
}