namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

/// <summary>
/// Command to create a new meeting.
/// </summary>
/// <param name="Title">
///   The title of the meeting to create.
/// </param>
/// <param name="Description">
///   The description of the meeting to create.
/// </param>
/// <param name="StartTime">
///   The start time of the meeting.
/// </param>
/// <param name="EndTime">
///   The end time of the meeting.
/// </param>
/// <param name="Date">
///   The date of the meeting.
/// </param>
/// <param name="Invitees">
///   The list of IDs of teachers invited to the meeting.
/// </param>
/// <param name="Responsible">
///   The list of IDs of administrators responsible for the meeting.
/// </param>
public record CreateMeetingCommand(Guid AdministratorId, string Title, string Description, DateTime StartTime, DateTime EndTime, DateTime Date, List<Guid> Invitees, List<Guid> Responsible);