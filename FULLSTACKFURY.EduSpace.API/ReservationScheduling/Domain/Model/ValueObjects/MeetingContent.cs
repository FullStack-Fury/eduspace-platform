namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public record MeetingContent(string Title, string Description, DateTime Date, TimeSpan StartTime, TimeSpan EndTime, List<InvitedTeacher> InvitedTeachers);