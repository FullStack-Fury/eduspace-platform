using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

/// <summary>
/// Service for handling queries related to administrators.
/// </summary>
public interface IAdministratorQueryService
{
    /// <summary>
    /// Retrieves an administrator by their unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the <see cref="Administrator"/> to retrieve.
    /// </param>
    /// <returns>
    /// The <see cref="Administrator"/> entity if found; otherwise, null.
    /// </returns>
    Task<Administrator?> GetByIdAsync(Guid id);

    /// <summary>
    /// Checks if an administrator exists by their email address.
    /// </summary>
    /// <param name="email">
    /// The email address of the administrator to check.
    /// </param>
    /// <returns>
    /// True if the administrator exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(string email);
}