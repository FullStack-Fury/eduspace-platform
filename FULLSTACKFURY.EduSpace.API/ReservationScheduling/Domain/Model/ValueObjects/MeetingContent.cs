namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

public record MeetingContent(string title, string description, DateTime date, TimeSpan startTime, TimeSpan endTime);