namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

public interface IClassroomContext
{
    bool ValidateClassroomNameExists(string name);
}