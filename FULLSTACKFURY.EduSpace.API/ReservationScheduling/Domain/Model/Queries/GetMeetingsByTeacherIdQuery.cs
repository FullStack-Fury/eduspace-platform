/// <summary>
/// Represents a query to get all meetings by teacher id in the EduSpace application.
/// </summary>
/// <param name="TeacherId">
/// The id of the teacher to get meetings for.
/// </param>
public record GetMeetingsByTeacherIdQuery(Guid TeacherId);