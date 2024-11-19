namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

public record UpdateMeetingResource(
    int MeetingId, 
    string Title,
    string Description,
    DateOnly Date,
    string Start,
    string End,
    int AdministratorId,
    int ClassroomId
);