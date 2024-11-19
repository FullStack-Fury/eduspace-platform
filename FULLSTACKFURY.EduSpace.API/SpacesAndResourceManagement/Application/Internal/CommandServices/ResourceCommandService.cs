using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.Internal.CommandServices;

/// <summary>
/// Represents a classroom command service for Classroom entities
/// </summary>
/// <param name="classroomRepository">
/// The repository for classroom entities
/// </param>
/// <param name="resourceRepository">
/// The repository for resource entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class ResourceCommandService(
    IClassroomRepository classroomRepository,
    IResourceRepository resourceRepository,
    IUnitOfWork unitOfWork) : IResourceCommandService
{
    public async Task<Resource?> Handle(CreateResourceCommand command)
    {
        var classroom = await classroomRepository.FindByIdAsync(command.ClassroomId);
        if(classroom is null) throw new Exception("Classroom not found");
        if(await resourceRepository.ExistsByNameAsync(command.Name)) throw new Exception("Resource with the same name already exists");
        var resource = new Resource(command);
        await resourceRepository.AddAsync(resource);
        await unitOfWork.CompleteAsync();
        resource.Classroom = classroom;
        return resource;
    } 
}