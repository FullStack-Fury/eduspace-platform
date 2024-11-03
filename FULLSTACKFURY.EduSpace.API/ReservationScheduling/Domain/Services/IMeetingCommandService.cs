using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

public interface IMeetingCommandService
{
    Task<Meeting?> Handle (CreateMeetingCommand command);
    void Handle(DeleteMeetingCommand command);
}