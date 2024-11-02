namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

/// <summary>
/// Command to create a teacher. 
/// </summary>
/// <param name="Name">
/// The name of the teacher to create.
/// </param>
///  <param name="Email">
///  The email of the teacher to create.
///  </param>
///  <param name="Phone">
///  The phone of the teacher to create.
///  </param>
///  <param name="Location">
///  The location of the teacher to create.
///  </param>
public record CreateTeacherCommand(string Name, string Email, string Phone, string Location);