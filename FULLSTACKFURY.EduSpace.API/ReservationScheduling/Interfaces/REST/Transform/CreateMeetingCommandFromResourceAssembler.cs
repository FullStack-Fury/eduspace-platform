using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Transform;

/// <summary>
/// Assembler class to transform CreateMeetingResource to CreateMeetingCommand
/// </summary>
public class CreateMeetingCommandFromResourceAssembler
{
    /// <summary>
    /// Transform CreateMeetingResource to CreateMeetingCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateMeetingResource"/> resource to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="CreateMeetingCommand"/> command with the values from the resource
    /// </returns>
    public static CreateMeetingCommand ToCommandFromResource(CreateMeetingResource resource)
    {
        return new CreateMeetingCommand(
            resource.Title,
            resource.Description,
            resource.StartTime,
            resource.EndTime,
            resource.Date,
            resource.Invitees, 
            resource.Responsible 
        );
    }
}