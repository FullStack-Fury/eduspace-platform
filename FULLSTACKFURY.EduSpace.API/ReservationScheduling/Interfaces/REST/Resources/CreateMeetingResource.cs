namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

/// <summary>
/// Represents the data required to create a new meeting.
/// </summary>
/// <param name="Title">
/// The title of the meeting.
/// </param>
/// <param name="Description">
/// The summary of the meeting.
/// </param>
/// <param name="StartTime">
/// The start time of the meeting.
/// </param>
/// <param name="EndTime">
/// The end time of the meeting.
/// </param>
/// <param name="Date">
/// The date of the meeting.
/// </param>
/// <param name="Invitees">
/// A collection of teacher identifiers for the invitees.
/// </param>
/// <param name="Responsible">
/// A collection of administrator identifiers for the responsible persons.
/// </param>
public record CreateMeetingResource(
    string Title,
    string Description,
    DateTime StartTime,
    DateTime EndTime,
    DateTime Date,
    List<Guid> Invitees,
    List<Guid> Responsible
);
