using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Application.Internal.QueryServices;

/// <summary>
/// Classroom query service
/// </summary>
/// <param name="classroomRepository">
/// The classroom repository
/// </param>
public class SharedAreaQueryService(ISharedAreaRepository sharedAreaRepository) : ISharedAreaQueryService
{
    /// <Inheritdoc/>
    public async Task<sharedArea?> Handle(GetSharedAreaByIdQuery query)
    {
        return await sharedAreaRepository.FindByIdAsync(query.SharedAreaId);
    }
    
    /// <Inheritdoc/>
    public async Task<IEnumerable<sharedArea>> Handle(GetAllSharedAreasQuery query)
    {
        return await sharedAreaRepository.ListAsync();
    }
}