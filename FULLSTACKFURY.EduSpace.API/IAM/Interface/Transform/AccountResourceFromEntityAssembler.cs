using FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.IAM.Interface.Resources;

namespace FULLSTACKFURY.EduSpace.API.IAM.Interface.Transform;

public static class AccountResourceFromEntityAssembler
{
    public static AccountResource ToResourceFromEntity(Account entity)
    {
        return new AccountResource(entity.Id, entity.Username);
    }
}