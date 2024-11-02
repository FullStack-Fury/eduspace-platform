namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

/// <summary>
/// Represents the data exposed by the teacher resource.
/// </summary>
/// <param name="TeacherId">
/// The unique identifier of the teacher.
/// </param>
/// <param name="Name">
/// The name of the teacher.
/// </param>
/// <param name="Surname">
/// The surname of the teacher.
/// </param>
/// <param name="Email">
/// The email address of the teacher.
/// </param>
/// <param name="Phone">
/// The phone number of the teacher.
/// </param>
public record TeachersResource(
    Guid TeacherId,
    string Name,
    string Surname,
    string Email,
    string Phone
);