using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC;

public class MeetingRepository(AppDbContext context) : BaseRepository<Meeting>(context), IMeetingRepository
{
    public async Task<Meeting?> GetByIdAsync(Guid meetingId)
    {
        return await Context.Set<Meeting>()
            .Include(meeting => meeting.Invitees)
            .Include(meeting => meeting.Responsible)
            .FirstOrDefaultAsync(meeting => meeting.MeetingId == meetingId);
    }

    public async Task<IEnumerable<Meeting>> GetAllAsync()
    {
        return await Context.Set<Meeting>()
            .Include(meeting => meeting.Invitees)
            .Include(meeting => meeting.Responsible)
            .ToListAsync();
    }

    public async Task UpdateStatusAsync(Guid meetingId, string status)
    {
        var meeting = await GetByIdAsync(meetingId);
        if (meeting != null)
        {
            meeting.UpdateStatus(status); // Assuming you have a method UpdateStatus in Meeting class
            await Context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Meeting>> FindByTeacherIdAsync(Guid teacherId) // Cambia el tipo a Guid
    {
        return await Context.Set<Meeting>()
            .Where(meeting => meeting.Invitees.Any(invitee => invitee.Id == teacherId)) // Usa Id en vez de TeacherId
            .ToListAsync();
    }

    public async Task<IEnumerable<Meeting>> FindByAdministratorIdAsync(Guid administratorId)
    {
        return await Context.Set<Meeting>()
            .Where(meeting => meeting.Responsible.Any(responsible => responsible.Id == administratorId))
            .ToListAsync();
    }

    public async Task<bool> ExistsByTitleAsync(string title)
    {
        return await Context.Set<Meeting>()
            .AnyAsync(meeting => meeting.Title == title);
    }
}