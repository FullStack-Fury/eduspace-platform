using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;

public class Meeting
    {
        public int MeetingId { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public MeetingDate MeetingDate { get;  private set; }
        public DateTime Date { get; private set; }
        
        public TeacherId TeacherId { get;  private set; }
        
        public AdminId AdminId { get; private set; }

        
        public Meeting()
        {
            MeetingDate = new MeetingDate();

        }
        public Meeting(string title, string description, DateTime start, DateTime end, DateTime date, int teacherId, int adminId)
        {
            Title = title;
            MeetingDate = new MeetingDate(start, end);
            Description = description;
            Date = date;
            TeacherId = new TeacherId(teacherId);
            AdminId = new AdminId(adminId);
        }
        
        public void UpdateMeetingDate(DateTime start, DateTime end)
        {
            MeetingDate = new MeetingDate(start, end);
        }
        
        public void UpdateTitle(string title)
        {
            Title = title;
        }
        
        public Meeting(CreateMeetingCommand command)
        {
            Title = command.Title;
            MeetingDate = new MeetingDate(command.Start, command.End);
            Description = command.Description;
            Date = command.Date;
            TeacherId = new TeacherId(command.TeacherId);
            AdminId = new AdminId(command.AdminId);
        }
    }