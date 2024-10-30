using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.CommandServices;

/// <summary>
/// Represents a classroom command service for Classroom entities
/// </summary>
/// <param name="teacherRepository">
/// The repository for teacher entities
/// </param>
/// <param name="classroomRepository">
/// The repository for classroom entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>
public class ClassroomCommandService(
    ITeacherRepository teacherRepository,
    IClassroomRepository classroomRepository,
    IUnitOfWork unitOfWork) : IClassroomCommandService
{
    
    /// <inheritdoc />
    public async Task<Classroom?> Handle(CreateClassroomCommand command)
    {
        var teacher = await teacherRepository.FindByIdAsync(command.TeacherId);
        if (teacher is null) throw new Exception("Teacher not found");
        if (await classroomRepository.ExistsByNameAsync(command.Name))
            throw new Exception("Classroom with the same title already exists");
        var classroom = new Classroom(command);
        await classroomRepository.AddAsync(classroom);
        await unitOfWork.CompleteAsync();
        classroom.Teacher = teacher;
        return classroom;
    }
}