using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;

public interface ITeacherRepository: IBaseRepository<Teacher>
{
    /// <summary>
    /// Finds a teacher by id asynchronously.
    /// </summary>
    /// <param name="id">
    /// The id of the teacher to find.
    /// </param>
    /// <returns>
    /// The teacher with the specified id.
    /// </returns>
    Task<Teacher?> GetTeacherByIdAsync(Guid id);
    
    Task<Teacher?> FindByIdAsync(Guid id);
    
    /// <summary>
    /// Checks if a teacher exists by email asynchronously.
    /// </summary>
    /// <param name="email">
    /// The email of the teacher to check.
    /// </param>
    /// <returns>
    /// True if the teacher exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(string email);
    
    
}
