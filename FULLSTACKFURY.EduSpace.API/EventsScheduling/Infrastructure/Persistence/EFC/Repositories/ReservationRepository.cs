using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FULLSTACKFURY.EduSpace.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Infrastructure.Persistence.EFC.Repositories;

public class ReservationRepository(AppDbContext context) 
    : BaseRepository<Reservation>(context), IReservationRepository
    
{
    public async Task<IEnumerable<Reservation>> FindByAreaIdAsync(int areaId)
    {
        return await Context.Set<Reservation>().Where(f => f.AreaId.Id == areaId).ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> FindByAreaIdMonthAndDayAsync(int areaId, int month, int day)
    {
        return await Context.Set<Reservation>().Where(f => f.AreaId.Id == areaId && f.ReservationDate.Start.Month == month && f.ReservationDate.Start.Day == day).ToListAsync();
    }
}