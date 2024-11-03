namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.OutboundServices.ACL;

public interface IExternalProfileService
{
    public bool VerifyProfile(int profileId);
}