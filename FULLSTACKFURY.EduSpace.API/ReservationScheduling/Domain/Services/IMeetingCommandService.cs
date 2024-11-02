using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

public interface IMeetingCommandService
{
    /// <summary>
    /// Handles the create meeting command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateMeetingCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Meeting"/> entity.
    /// </returns>
    Task<Meeting?> Handle(CreateMeetingCommand command);
}