namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;

public interface IExternalClassroomService
{
    public bool VerifyClassroom(int classroomId);
}