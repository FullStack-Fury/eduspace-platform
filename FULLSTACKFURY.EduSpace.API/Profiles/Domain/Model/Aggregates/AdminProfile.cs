namespace FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Aggregates;

public class AdminProfile : Profile
{
    public AdminProfile(string firstName, string lastName, string email, string dni, string address, string phone, int accountId) 
        : base(firstName, lastName, email, dni, address, phone, accountId)
    {
    }
}