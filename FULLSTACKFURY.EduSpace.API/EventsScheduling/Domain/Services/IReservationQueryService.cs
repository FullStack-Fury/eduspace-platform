using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Queries;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Services;

public interface IReservationQueryService
{
    Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery query);
    Task<IEnumerable<Reservation>> Handle(GetReservationsByAreaIdQuery query);
    Task<IEnumerable<Reservation>> Handle(GetReservationByAreaIdMonthAndDay query);

}