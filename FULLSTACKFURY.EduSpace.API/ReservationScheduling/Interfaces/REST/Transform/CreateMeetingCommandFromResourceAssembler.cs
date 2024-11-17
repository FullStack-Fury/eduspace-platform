using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;

public class CreateMeetingCommandFromResourceAssembler
{
    public static CreateMeetingCommand ToCommandFromResource(CreateMeetingResource resource)
    {
        var teachers = resource.Teachers.Select(teacher => 
            (teacher.Id, teacher.FirstName, teacher.LastName)
        ).ToList();
        
        return new CreateMeetingCommand(
            resource.Title,
            resource.Description,
            resource.Date,
            resource.Start,
            resource.End,
            teachers,
            resource.AdminId,
            resource.ClassroomName);
    }
}