using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;

/// <summary>
///  Represents a repository for shared areas in the EduSpace API.
/// </summary>
public interface ISharedAreaRepository : IBaseRepository<sharedArea>
{
    /// <summary>
    ///  Verify if a shared area with specified title exists.
    /// </summary>
    /// <param name="name">
    /// The name of the shared area to verify.
    /// </param>
    /// <returns>
    /// True if the shared area exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByNameAsync(string name);
}