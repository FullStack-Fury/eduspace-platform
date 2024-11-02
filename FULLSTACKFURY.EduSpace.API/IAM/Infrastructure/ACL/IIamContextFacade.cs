namespace FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.ACL;

public interface IIamContextFacade
{
    Task<int> CreateAccount(string username, string password, string role);
}