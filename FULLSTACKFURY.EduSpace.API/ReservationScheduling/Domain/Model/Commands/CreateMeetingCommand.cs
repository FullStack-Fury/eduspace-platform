using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

public record CreateMeetingCommand(string Title, string Description, DateTime Start, DateTime End, List<InvitedTeacher> InvitedTeachers);