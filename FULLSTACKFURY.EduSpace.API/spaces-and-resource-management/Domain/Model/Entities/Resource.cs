

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

public class Resource
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Kind_of_resource { get; private set; }
    public Classroom Classroom { get; private set; }
    public int ClassroomId { get; private set; }
    
    /// <summary>
    /// Default constructor for the resource entity 
    /// </summary>
    /// <param name="name">
    /// The name of the resource
    /// </param>
    /// <param name="kind_of_resource">
    /// The kind of resource
    /// </param>
    /// <param name="classroomId">
    /// The classroom id for the resource
    /// </param>
    public Resource(int id, string name, string kind_of_resource, int classroomId)
    {
        Id = id;
        Name = name;
        Kind_of_resource = kind_of_resource;
        ClassroomId = classroomId;
    }
}