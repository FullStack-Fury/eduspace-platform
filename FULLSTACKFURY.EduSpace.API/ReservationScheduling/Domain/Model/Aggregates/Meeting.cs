using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;

public class Meeting
{
    public int MeetingId { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; } 
    public TimeOnly EndTime { get; private set; }
    
    // public List<Teacher> Teachers { get; private set; } 
    public AdministratorId AdministratorId { get; private set; }
    public ClassroomId ClassroomId { get; private set; }

    public Meeting(string title, string description, DateOnly date, 
                    TimeOnly start, TimeOnly end,
                    int administratorId, int classroomId)
    {
        Title = title;
        Description = description;
        Date = date;
        StartTime = start;
        EndTime = end;
        AdministratorId = new AdministratorId(administratorId);
        ClassroomId = new ClassroomId(classroomId);
    }

    public Meeting(CreateMeetingCommand command)
    {
        Title = command.Title;
        Description = command.Description;
        Date = command.Date;
        StartTime = command.Start;
        EndTime = command.End;
        AdministratorId = new AdministratorId(command.AdministratorId);
        ClassroomId = new ClassroomId(command.ClassroomId);
    }
}