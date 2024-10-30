using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Entities;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the teacher repository in the EduSpace API.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext"/> to use.
/// </param>
public class TeacherRepository(AppDbContext context): BaseRepository<Teacher>(context), ITeacherRepository;