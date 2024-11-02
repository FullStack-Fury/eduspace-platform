namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;

public record CreateAdministratorCommand(string Name, string Email, string Phone, string Location);