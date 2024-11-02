using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;

public interface IAdministratorRepository: IBaseRepository<Administrator>
{
    /// <summary>
    /// Finds an administrator by id asynchronously.
    /// </summary>
    /// <param name="id">
    /// The id of the administrator to find.
    /// </param>
    /// <returns>
    /// The administrator with the specified id.
    /// </returns>
    Task<Administrator?> GetAdministratorByIdAsync(Guid id);
        
    Task<Administrator?> FindByIdAsync(Guid id);
    
    /// <summary>
    /// Checks if an administrator exists by email asynchronously.
    /// </summary>
    /// <param name="email">
    /// The email of the administrator to check.
    /// </param>
    /// <returns>
    /// True if the administrator exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(string email);
}
