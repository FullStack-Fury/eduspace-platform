namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

/// <summary>
/// Represents the data exposed by the administrator resource.
/// </summary>
/// <param name="AdministratorId">
/// The unique identifier of the administrator.
/// </param>
/// <param name="Name">
/// The name of the administrator.
/// </param>
/// <param name="Surname">
/// The surname of the administrator.
/// </param>
/// <param name="Email">
/// The email address of the administrator.
/// </param>
/// <param name="Phone">
/// The phone number of the administrator.
/// </param>
public record AdministratorResource(
    Guid AdministratorId,
    string Name,
    string Surname,
    string Email,
    string Phone
);