using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.OutboundServices.ACL;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Application.Internal.CommandServices;

/// <summary>
/// Represents a classroom command service for Classroom entities
/// </summary>
/// <param name="classroomRepository">
/// The repository for classroom entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class ClassroomCommandService(
    
    IClassroomRepository classroomRepository,
    IExternalProfileService profileService,
    IUnitOfWork unitOfWork) : IClassroomCommandService
{
    
    /// <inheritdoc />
    public async Task<Classroom?> Handle(CreateClassroomCommand command)
    {
        if(profileService.VerifyProfile(command.TeacherId) == false) throw new Exception("Teacher not found");
        if (await classroomRepository.ExistsByNameAsync(command.Name))
            throw new Exception("Classroom with the same title already exists");
        var classroom = new Classroom(command);
        await classroomRepository.AddAsync(classroom);
        await unitOfWork.CompleteAsync();
        return classroom;
    }
}