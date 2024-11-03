using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Infrastructure.Persistence.EFC.Repositories;

public class ResourceRepository(AppDbContext context): BaseRepository<Resource>(context), IResourceRepository
{
    // inheritedDoc
    public async Task<IEnumerable<Resource>> FindByClassroomIdAsync(int classroomId)
    {
        return await Context.Set<Resource>()
            .Include(resource => resource.Classroom)
            .Where(resource => resource.ClassroomId == classroomId)
            .ToListAsync(); 
    }
    
    // inheritedDoc
    public new async Task<Resource?> FindByIdAsync(int id)
    {
        return await Context.Set<Resource>()
            .Include(resource => resource.Classroom)
            .FirstOrDefaultAsync(resource => resource.Id == id);
    }
    
    // inheritedDoc
    public async Task<IEnumerable<Resource>> ListAsync()
    {
        return await Context.Set<Resource>()
            .Include(resource => resource.Classroom)
            .ToListAsync();
    }
    
    // inheritedDoc
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await Context.Set<Resource>()
            .AnyAsync(resource => resource.Name == name);
    }
}