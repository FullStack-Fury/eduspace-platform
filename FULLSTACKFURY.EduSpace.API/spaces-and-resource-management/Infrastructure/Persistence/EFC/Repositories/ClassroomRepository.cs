using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Infrastructure.Persistence.EFC.Repositories;

public class ClassroomRepository(AppDbContext context)
    : BaseRepository<Classroom>(context), IClassroomRepository
{
    public async Task<IEnumerable<Classroom>> FindByTeacherIdAsync(int teacherId)
    {
        return await Context.Set<Classroom>()
            .Include(classroom => classroom.TeacherId)
            .Where(classroom => classroom.TeacherId == teacherId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Classroom>> FindByIdAsync(int id)
    {
        return await Context.Set<Classroom>()
            .Include(classroom => classroom.Id)
            .Where(classroom => classroom.Id == id)
            .ToListAsync();
    }
}