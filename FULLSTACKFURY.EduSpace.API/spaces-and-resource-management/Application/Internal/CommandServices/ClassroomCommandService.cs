using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.CommandServices;

public class ClassroomCommandService(IClassroomRepository classroomRepository, IUnitOfWork unitOfWork) : IClassroomCommandService
{
    public async Task<Classroom?> Handle(CreateClassroomCommand command)
    {
        var classroom = new Classroom(command);

        await classroomRepository.AddAsync(classroom);
        await unitOfWork.CompleteAsync();
        return classroom;
    }
}