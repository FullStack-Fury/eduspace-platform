using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;

public interface IMeetingRepository
{
     /// <summary>
    /// Adds a new meeting asynchronously.
    /// </summary>
    /// <param name="meeting">
    /// The meeting to add.
    /// </param>
    Task AddAsync(Meeting meeting);

    /// <summary>
    /// Retrieves a meeting by its unique identifier asynchronously.
    /// </summary>
    /// <param name="meetingId">
    /// The unique identifier of the meeting to retrieve.
    /// </param>
    /// <returns>
    /// The meeting with the specified identifier, or null if not found.
    /// </returns>
    Task<Meeting?> GetByIdAsync(Guid meetingId);

    /// <summary>
    /// Retrieves all meetings asynchronously.
    /// </summary>
    /// <returns>
    /// A collection of all meetings.
    /// </returns>
    Task<IEnumerable<Meeting>> GetAllAsync();

    /// <summary>
    /// Updates the status of a meeting asynchronously.
    /// </summary>
    /// <param name="meetingId">
    /// The unique identifier of the meeting to update.
    /// </param>
    /// <param name="status">
    /// The new status of the meeting.
    /// </param>
    Task UpdateStatusAsync(Guid meetingId, string status);

    /// <summary>
    /// Finds meetings by teacher identifier asynchronously.
    /// </summary>
    /// <param name="teacherId">
    /// The id of the teacher to find meetings by.
    /// </param>
    /// <returns>
    /// A collection of meetings that belong to the teacher.
    /// </returns>
    Task<IEnumerable<Meeting>> FindByTeacherIdAsync(Guid teacherId);

    /// <summary>
    /// Finds meetings by administrator identifier asynchronously.
    /// </summary>
    /// <param name="administratorId">
    /// The id of the administrator to find meetings by.
    /// </param>
    /// <returns>
    /// A collection of meetings that belong to the administrator.
    /// </returns>
    Task<IEnumerable<Meeting>> FindByAdministratorIdAsync(Guid administratorId); // Método agregado

    /// <summary>
    /// Verifies if a meeting with the specified title exists.
    /// </summary>
    /// <param name="title">
    /// The title of the meeting to verify.
    /// </param>
    /// <returns>
    /// True if the meeting exists, otherwise false.
    /// </returns>
    Task<bool> ExistsByTitleAsync(string title);
}