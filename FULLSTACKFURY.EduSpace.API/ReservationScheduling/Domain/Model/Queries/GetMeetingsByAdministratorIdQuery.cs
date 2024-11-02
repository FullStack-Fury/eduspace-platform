namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;

/// <summary>
/// Represents a query to get all meetings by administrator id in the EduSpace application.
/// </summary>
/// <param name="AdministratorId">
/// The id of the administrator to get meetings for.
/// </param>
public record GetMeetingsByAdministratorIdQuery(Guid AdministratorId);