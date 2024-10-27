using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_mangement.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Services;

public interface IClassroomQueryService
{
    Task<IEnumerable<Classroom>> Handle(GetAllClassroomQuery query); 
    Task<Classroom?> Handle(GetClassroomByIdQuery query);
    Task<IEnumerable<Classroom>> Handle(GetAllClassroomByResourceIdQuery query);
} 