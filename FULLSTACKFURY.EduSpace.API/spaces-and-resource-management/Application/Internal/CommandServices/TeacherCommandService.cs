using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.CommandServices;

/// <summary>
/// Representes a teacher command service for Teacher entities
/// </summary>
/// <param name="teacherRepository">
///   The repository for teacher entities
/// </param>
/// <param name="unitOfWork">
///  The unit of work for the repository
/// </param>
public class TeacherCommandService(
    ITeacherRepository teacherRepository,
    IUnitOfWork unitOfWork) : ITeacherCommandService
{
    public async Task<Teacher?> Handle(CreateTeacherCommand command)
    {
        var teacher = new Teacher(command);
        await teacherRepository.AddAsync(teacher);
        await unitOfWork.CompleteAsync();
        return teacher;
    }
}