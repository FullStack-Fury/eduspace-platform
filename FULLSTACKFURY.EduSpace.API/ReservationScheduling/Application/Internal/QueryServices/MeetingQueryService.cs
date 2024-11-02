using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;

public class MeetingQueryService(IMeetingRepository meetingRepository) : IMeetingQueryService
{
    /// <inheritdoc />
    public async Task<Meeting?> Handle(GetMeetingByIdQuery query)
    {
        return await meetingRepository.GetByIdAsync(query.MeetingId);
    }

    public async Task<IEnumerable<Meeting>> Handle(GetAllMeetingsQuery query)
    {
        return await meetingRepository.GetAllAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Meeting>> Handle(GetMeetingsByTeacherIdQuery query)
    {
        return await meetingRepository.FindByTeacherIdAsync(query.TeacherId);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Meeting>> Handle(GetMeetingsByAdministratorIdQuery query)
    {
        return await meetingRepository.FindByAdministratorIdAsync(query.AdministratorId);
    }
}