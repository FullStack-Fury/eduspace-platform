using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

/// <summary>
/// Represents the teacher query service in the EduSpace API. 
/// </summary>
public interface ITeacherQueryService
{
    /// <summary>
    /// Handles the get teacher by id query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetTeacherByIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// The teacher with the specified id.
    /// </returns>
    Task<Teacher?> Handle(GetTeacherByIdQuery query);
    
    /// <summary>
    /// Handles the get all teachers query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllTeachersQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all teachers in the platform.
    /// </returns>
    Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery query);
}