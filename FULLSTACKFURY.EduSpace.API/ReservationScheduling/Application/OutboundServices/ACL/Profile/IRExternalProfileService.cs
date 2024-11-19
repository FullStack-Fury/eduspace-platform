namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public interface IRExternalProfileService
{
    public bool VerifyProfile(int profileId);
    bool ValidateTeacherExistence(int teacherId); 
    bool ValidateAdminIdExistence(int adminId);
    
    bool ValidateTeachersExistence(List<int> teacherIds);
}