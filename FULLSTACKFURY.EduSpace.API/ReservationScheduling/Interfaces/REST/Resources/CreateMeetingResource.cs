using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

public record CreateMeetingResource(
    string Title,
    string Description,
    DateOnly Date,
    string Start,
    string End,
    int AdministratorId,
    int ClassroomId
);
