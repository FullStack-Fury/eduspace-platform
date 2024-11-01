using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

/// <summary>
/// Represents a shared area in the application.
/// </summary>
/// <remarks>
/// This class is used to represent a shared area in the application.
/// </remarks>
public partial class sharedArea
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
    
    /// <summary>
    /// Default constructor for the shared area entity
    /// </summary>
    public sharedArea()
    {
    }
    
    /// <param name="name">
    /// The name of the shared area
    /// </param>
    /// <param name="capacity">
    /// The capacity of the shared area
    /// </param>
    /// <param name="description">
    /// The description of the shared area
    /// </param>
    public sharedArea(string name, int capacity, string description): this()
    {
        Name = name;
        Capacity = capacity;
        Description = description;
    }
    
    public sharedArea(CreateSharedAreaCommand command): this()
    {
        Name = command.Name;
        Capacity = command.Capacity;
        Description = command.Description;
    }
}