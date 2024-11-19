using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC;

public class MeetingRepository(AppDbContext context)
        : BaseRepository<Meeting>(context), IMeetingRepository
{
        public async Task<IEnumerable<Meeting>> FindAllByAdminIdAsync(int adminId)
        {
                return await Context.Set<Meeting>().
                        Where(m =>m.AdministratorId.AdministratorIdentifier == adminId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Meeting>> FindAllByClassroomIdAsync(int classroomId)
        {
                return await Context.Set<Meeting>().
                        Where(m => m.ClassroomId.ClassroomIdentifier == classroomId)
                        .ToListAsync();
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
                return await Context.Set<Meeting>()
                        .AnyAsync(m => m.Title == title);
        }
        
        public new async Task<Meeting?> FindByIdAsync(int id)
        {
                return await Context.Set<Meeting>()
                        .FirstOrDefaultAsync(meeting => meeting.Id == id);
        }
        
        public new async Task<IEnumerable<Meeting>> ListAsync()
        {
                return await Context.Set<Meeting>()
                        .ToListAsync();
        }
        
}