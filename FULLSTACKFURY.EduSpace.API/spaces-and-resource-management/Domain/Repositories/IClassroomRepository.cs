using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;

/// <summary>
/// Represents the Classroom repository in the Platform. 
/// </summary>
public interface IClassroomRepository : IBaseRepository<Classroom> 
{
    /// <summary>
    /// Finds a Classroom by classroom id asynchronously. 
    /// </summary>
    /// <param name="classroomId">
    /// The id of the classroom to find classrooms by.
    /// </param>
    /// <returns>
    /// A collection of classroom that belong to the resource.
    /// </returns>
    Task<IEnumerable<Classroom>> FindByIdAsync(int classroomId);
    
    /// <summary>
    /// Finds a Classroom by teacher id asynchronously.
    /// </summary>
    /// <param name="teacherId">
    /// The id of the teacher to find classrooms by.
    /// </param>
    /// <returns>
    /// A collection of classroom that belong to the teacher.
    /// </returns>
    Task<IEnumerable<Classroom>> FindByTeacherIdAsync(int teacherId);
}