using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.CommandServices;

/// <summary>
/// Represents a shared area command service for Shared Area entities
/// </summary>
/// <param name="sharedAreaRepository">
/// The repository for shared area entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class SharedAreaCommandService(ISharedAreaRepository sharedAreaRepository, IUnitOfWork unitOfWork) : ISharedAreaCommandService
{
    /// <inheritDoc />
    public async Task<SharedArea?> Handle(CreateSharedAreaCommand command)
    {
        if(await sharedAreaRepository.ExistsByNameAsync(command.Name))
            throw new Exception("Shared area with the same name already exists.");
        var sharedArea = new SharedArea(command);
        await sharedAreaRepository.AddAsync(sharedArea);
        await unitOfWork.CompleteAsync();
        return sharedArea;
    }
}