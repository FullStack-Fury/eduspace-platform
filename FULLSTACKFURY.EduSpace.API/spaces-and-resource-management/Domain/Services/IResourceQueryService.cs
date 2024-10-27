using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_mangement.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

public interface IResourceQueryService
{
    Task<IEnumerable<Resource>> Handle(GetAllResourcesQuery query); 
    Task<Resource?> Handle(GetResourceByIdQuery query);
}