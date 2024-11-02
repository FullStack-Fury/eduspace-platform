using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;

public class Meeting
    {
        public Guid MeetingId { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Date { get; private set; }
        public string Status { get; private set; }
        public List<Teacher> Invitees { get; private set; } = new List<Teacher>();
        public List<Administrator> Responsible { get; private set; } = new List<Administrator>();

        public Meeting(string title, string description, DateTime startTime, DateTime endTime, DateTime date, List<Teacher> invitees = null, List<Administrator> responsible = null)
        {
            MeetingId = Guid.NewGuid();
            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Invitees = invitees ?? new List<Teacher>(); // Esta línea está bien
            Responsible = responsible ?? new List<Administrator>(); // Esta línea está bien
            Status = "Scheduled"; 
        }

        public static async Task<Meeting> CreateFromCommandAsync(CreateMeetingCommand command, ITeacherRepository teacherRepository, IAdministratorRepository administratorRepository)
        {
            var inviteesTasks = command.Invitees.Select(id => teacherRepository.GetTeacherByIdAsync(id));
            var responsibleTasks = command.Responsible.Select(id => administratorRepository.GetAdministratorByIdAsync(id));

            var invitees = await Task.WhenAll(inviteesTasks);
            var responsible = await Task.WhenAll(responsibleTasks);
            
            var meeting = new Meeting(command.Title, command.Description, command.StartTime, command.EndTime, command.Date, invitees.ToList(), responsible.ToList());
            return meeting;
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                throw new ArgumentException("The state cannot be empty", nameof(newStatus));
            }

            Status = newStatus;
        }
    }