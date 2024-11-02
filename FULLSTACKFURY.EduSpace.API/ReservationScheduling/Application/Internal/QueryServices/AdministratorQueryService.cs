using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;

public class AdministratorQueryService(IAdministratorRepository administratorRepository) : IAdministratorQueryService
{
    public async Task<Administrator?> GetByIdAsync(Guid id)
    {
        return await administratorRepository.FindByIdAsync(id);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await administratorRepository.ExistsByEmailAsync(email);
    }
}