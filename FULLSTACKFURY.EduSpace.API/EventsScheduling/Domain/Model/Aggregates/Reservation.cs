using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.ValueObjects;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;

public class Reservation
{
    public int Id { get;  }
    public string Title { get; private set; }
    public ReservationDate ReservationDate { get; private set; }
    public AreaId AreaId { get; private set; }
    public TeacherId TeacherId { get; private set; }
    
    

}