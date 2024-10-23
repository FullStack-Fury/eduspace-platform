using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.EventsScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.EventsScheduling.Application.Internal.CommandServices;

public class ReservationCommandService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork) : IReservationCommandService

{
    public async Task<Reservation?> Handle(CreateReservationCommand command)
    {
        //Can improve this using static methods for command creation and use custom domain exceptions
        var reservation = new Reservation(command);

        var reservationsOfTheDay =
            await reservationRepository.FindByAreaIdMonthAndDayAsync(command.AreaId, command.Start.Month,
                command.Start.Day);
        var reservationsOfTheDayList = reservationsOfTheDay.ToList();
        
        if (!reservation.CanReserve(reservationsOfTheDayList))
        {
            throw new Exception("Reservation cannot be made. Area is already reserved for the given time");
        }
        
        await reservationRepository.AddAsync(reservation);
        await unitOfWork.CompleteAsync();
        return reservation;

    }
}