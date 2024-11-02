using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;


/// <summary>
/// Service for handling commands related to teachers.
/// </summary>
public interface ITeacherCommandService
{
    /// <summary>
    /// Handles the create teacher command in the EduSpace API.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateTeacherCommand"/> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Teacher"/> entity.
    /// </returns>
    Task<Teacher?> Handle(CreateTeacherCommand command);
}