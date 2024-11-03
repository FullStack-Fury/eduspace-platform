using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Infrastructure.Persistence.EFC.Repositories;


public class ClassroomRepository(AppDbContext context) : BaseRepository<Classroom>(context), IClassroomRepository
{
    // InheritedDoc

    public async Task<IEnumerable<Classroom>> FindByTeacherIdAsync(int teacherId)
    {
        return await Context.Set<Classroom>()
            .Include(classroom => classroom.Teacher)
            .Where(classroom => classroom.TeacherId == teacherId)
            .ToListAsync(); 
    }
    
    // InheritedDoc
    public new async Task<Classroom?> FindByIdAsync(int id)
    {
        return await Context.Set<Classroom>()
            .Include(classroom => classroom.Teacher)
            .FirstOrDefaultAsync(classroom => classroom.Id == id); 
    }
    
    
    // InheritedDoc
    public new async Task<IEnumerable<Classroom>> ListAsync()
    {
        return await Context.Set<Classroom>()
            .Include(classroom => classroom.Teacher)
            .ToListAsync();
    }
    
    // InheritedDoc
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await Context.Set<Classroom>()
            .AnyAsync(classroom => classroom.Name == name); 
    }
}

