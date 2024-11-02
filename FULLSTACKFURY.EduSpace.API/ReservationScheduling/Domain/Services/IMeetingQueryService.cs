using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

public interface IMeetingQueryService
{
    /// <summary>
    /// Handles the get meeting by id query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetMeetingByIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="Meeting"/> entity.
    /// </returns>
    Task<Meeting?> Handle(GetMeetingByIdQuery query);
    
    /// <summary>
    /// Handles the get all meetings query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllMeetingsQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all meetings in the platform.
    /// </returns>
    Task<IEnumerable<Meeting>> Handle(GetAllMeetingsQuery query);
    
    /// <summary>
    /// Handles the get all meetings by teacher id query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetMeetingsByTeacherIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of meetings that belong to the teacher.
    /// </returns>
    Task<IEnumerable<Meeting>> Handle(GetMeetingsByTeacherIdQuery query);

    /// <summary>
    /// Handles the get all meetings by administrator id query in the EduSpace API.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetMeetingsByAdministratorIdQuery"/> query to handle.
    /// </param>
    /// <returns>
    /// A collection of meetings that belong to the administrator.
    /// </returns>
    Task<IEnumerable<Meeting>> Handle(GetMeetingsByAdministratorIdQuery query);
}