using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FULLSTACKFURY.EduSpace.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class AdminProfileRepository(AppDbContext context) : BaseRepository<AdminProfile>(context), IAdminProfileRepository
{
    public bool ExistsByAdminProfileId(int adminProfileId)
    {
        return Context.Set<AdminProfile>().Any(adminProfile => adminProfile.Id == adminProfileId);
    }
}