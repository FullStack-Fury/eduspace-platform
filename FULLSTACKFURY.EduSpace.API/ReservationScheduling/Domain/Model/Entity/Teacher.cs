using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

public class Teacher
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public List<Meeting> Meetings { get; set; } = new List<Meeting>();

    public Teacher(string name, string email, string phone, string location)
    {
        Id = Guid.NewGuid(); // Asegúrate de establecer un nuevo GUID
        Name = name;
        Email = email;
        Phone = phone;
        Location = location;
    }

    public Teacher(CreateTeacherCommand command)
    {
        Id = Guid.NewGuid(); // Asegúrate de establecer un nuevo GUID
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        Location = command.Location;
    }
}