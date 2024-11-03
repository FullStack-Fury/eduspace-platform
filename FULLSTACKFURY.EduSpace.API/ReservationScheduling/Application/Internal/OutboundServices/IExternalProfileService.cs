namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public interface IExternalProfileService
{
    bool ValidateTeacherIdExistence(int teacherId);
    bool ValidateAdminIdExistence(int teacherId);
}