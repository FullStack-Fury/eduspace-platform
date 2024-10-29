using FULLSTACKFURY.EduSpace.API.IAM.Infrastructure.ACL.Services;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.Profiles.Application.Internal.OutboundServices.ACL;

public class ExternalIamService(IamContextFacade iamContextFacade)
{
    public async Task<AccountId> CreateAccount(string username, string password, string role)
    {
        var accountId = await iamContextFacade.CreateAccount(username, password, role);
        if (accountId == 0) throw new Exception("Error creating the account");
        return new AccountId(accountId);
    }
}