using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

public class Administrator
{
    public Guid Id { get; set; } // Cambiado a Guid
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public List<Meeting> Meetings { get; set; } = new List<Meeting>();

    public Administrator(string name, string email, string phone, string location)
    {
        Id = Guid.NewGuid(); // Asegúrate de establecer un nuevo GUID
        Name = name;
        Email = email;
        Phone = phone;
        Location = location;
    }

    public Administrator(CreateAdministratorCommand command)
    {
        Id = Guid.NewGuid(); // Asegúrate de establecer un nuevo GUID
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        Location = command.Location;
    }
}