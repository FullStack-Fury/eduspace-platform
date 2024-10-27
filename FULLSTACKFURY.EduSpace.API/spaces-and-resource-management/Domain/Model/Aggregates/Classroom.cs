
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

/// <summary>
/// Represents a classroom in the application. 
/// </summary>
/// <remarks>
/// A classroom is a space that is used for teaching and learning.
/// </remarks>
public class Classroom
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public  TeacherId Teacher { get; private set; }
    
    public int TeacherId { get; private set; }
    
    public Classroom(string name, string description, int teacherId)
    {
        Name = name;
        Description = description;
        TeacherId = teacherId;
        
    }
    
    public Classroom(CreateClassroomCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        TeacherId = command.TeacherId;
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
    
    public void UpdateDescription(string description)
    {
        Description = description;
    }
}