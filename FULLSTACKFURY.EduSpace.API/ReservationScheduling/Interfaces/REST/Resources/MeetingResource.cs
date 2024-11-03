namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

public record MeetingResource(
    int MeetingId,
    string Title,
    string Description,
    DateTime Start,
    DateTime End,
    DateTime Date
);