using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.ACL;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.OutboundServices.ACL;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade) : IExternalProfileService
{
    public bool VerifyProfile(int teacherProfileId)
    {
        return profilesContextFacade.ValidateTeacherProfileIdExistence(teacherProfileId);
    }
}