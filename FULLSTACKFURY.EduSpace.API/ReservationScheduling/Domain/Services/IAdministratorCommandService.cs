using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

/// <summary>
/// Service for handling commands related to administrators.
/// </summary>
public interface IAdministratorCommandService
{
    /// <summary>
    /// Handles the create administrator command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateAdministratorCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Administrator"/> entity.
    /// </returns>
    Task<Administrator?> Handle(CreateAdministratorCommand command);
}
