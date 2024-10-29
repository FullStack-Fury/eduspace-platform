using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Aggregates;

public class TeacherProfile : Profile
{
    public int AdministratorId { get; private set; }
    
    public TeacherProfile(string firstName, string lastName, string email
        , string dni, string address, string phone, AccountId accountId
        , int administratorId) 
        : base(firstName, lastName, email, dni, address, phone, accountId)
    {
        AdministratorId = administratorId;
    }

    public TeacherProfile(CreateTeacherProfileCommand command, AccountId accountId)
        : base(command.FirstName, command.LastName, command.Email, command.Dni,
            command.Address, command.Phone, accountId)
    {
        AdministratorId = command.AdministratorId;
    }
}