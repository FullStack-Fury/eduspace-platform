using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.QueryServices;

/// <summary>
/// Teacher query service
/// </summary>
/// <param name="teacherRepository">
/// The teacher repository
/// </param>
public class TeacherQueryService(ITeacherRepository teacherRepository): ITeacherQueryService
{
    /// <inheritdoc />
    public async Task<Teacher?> Handle(GetTeacherByIdQuery query)
    {
        return await teacherRepository.FindByIdAsync(query.TeacherId);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery query)
    {
        return await teacherRepository.ListAsync();
    }
}