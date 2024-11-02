using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;

public class AdministratorCommandService(
    IAdministratorRepository administratorRepository,
    IUnitOfWork unitOfWork) : IAdministratorCommandService
{
    public async Task<Administrator?> Handle(CreateAdministratorCommand command)
    {
        if (await administratorRepository.ExistsByEmailAsync(command.Email))
            throw new Exception("Administrator with the same email already exists");

        var administrator = new Administrator(command);
        await administratorRepository.AddAsync(administrator);
        await unitOfWork.CompleteAsync();
        return administrator;
    }
}