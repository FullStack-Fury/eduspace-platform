namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

public record MeetingResource(
    Guid MeetingId,
    string Title,
    string Description,
    DateTime StartTime,
    DateTime EndTime,
    DateTime Date,
    List<TeachersResource> Invitees,
    List<AdministratorResource> Responsible
);