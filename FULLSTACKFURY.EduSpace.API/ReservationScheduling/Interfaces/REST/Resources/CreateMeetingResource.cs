namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

public record CreateMeetingResource(
    string Title,
    string Description,
    DateTime Start,
    DateTime End,
    DateTime Date,
    int TeacherId,
    int AdminId
);
