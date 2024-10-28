namespace FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST.Resources;

public record CreateTeacherProfileResource (string FirstName, string LastName, string Email, string Dni
    , string Address, string Phone, int AccountId, string Username, string Password, string Role)
{
    
}