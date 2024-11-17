namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public interface IExternalClassroomService
{
    bool ValidateClassroomName(string name);
}