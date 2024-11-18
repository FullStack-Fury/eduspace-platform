namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public interface IExternalProfileService
{
    bool ValidateTeacherExistence(int teacherId); 
    bool ValidateAdminIdExistence(int adminId);
    
    bool ValidateTeachersExistence(List<int> teacherIds);
}