namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.ValueObjects;

/// <summary>
/// Represents the teacher identifier in the Platform. 
/// </summary>
/// <param name="Id">
/// The id of the teacher.
/// </param>
public record TeacherId
{
    public int Id { get; init; }
    
    public TeacherId(int id)
    {
        if(id<=0) throw new ArgumentException("Teacher Id cannot be less than or equal to 0");
    }
}