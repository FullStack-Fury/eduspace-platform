namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Aggregates;

public class TeacherProfile : Profile
{
    public int AdministratorId { get; private set; }
    
    public TeacherProfile(string firstName, string lastName, string email
        , string dni, string address, string phone, int accountId
        , int administratorId) 
        : base(firstName, lastName, email, dni, address, phone, accountId)
    {
        AdministratorId = administratorId;
    }
}