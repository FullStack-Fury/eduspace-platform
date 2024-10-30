using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;

/// <summary>
/// Represents a teacher in the EduSpace application.
/// </summary>
public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }

    public Teacher(string name, string email, string phone, string location)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Location = location;
    }
    
    public Teacher(CreateTeacherCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        Location = command.Location;
    }
}