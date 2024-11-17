using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.REST.Transform;

public class MeetingResourceFromEntityAssembler
{
    public static MeetingResource ToResourceFromEntity(Meeting entity)
    {
        var teachers = entity.Teachers.Select(teacher => new Teacher(
            teacher.Id,
            teacher.FirstName,
            teacher.LastName
        )).ToList();
        
        return new MeetingResource(
            entity.MeetingId,
            entity.Title,
            entity.Description,
            entity.Date,
            entity.StartTime,
            entity.EndTime,
            teachers,
            entity.AdminId,
            entity.ClassroomName);
    }
}