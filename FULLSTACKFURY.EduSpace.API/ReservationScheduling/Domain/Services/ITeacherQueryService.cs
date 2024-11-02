using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;

/// <summary>
/// Service for handling queries related to teachers.
/// </summary>
public interface ITeacherQueryService
{
    /// <summary>
    /// Retrieves a teacher by their unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the <see cref="Teacher"/> to retrieve.
    /// </param>
    /// <returns>
    /// The <see cref="Teacher"/> entity if found; otherwise, null.
    /// </returns>
    Task<Teacher?> GetByIdAsync(Guid id);

    /// <summary>
    /// Checks if a teacher exists by their email address.
    /// </summary>
    /// <param name="email">
    /// The email address of the teacher to check.
    /// </param>
    /// <returns>
    /// True if the teacher exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(string email);
}