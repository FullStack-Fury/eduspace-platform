using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Repositories;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<IEnumerable<Reservation>> FindByAreaIdAsync(int areaId);

    Task<IEnumerable<Reservation>> FindByAreaIdMonthAndDayAsync(int areaId, int month, int day);
    
    
}