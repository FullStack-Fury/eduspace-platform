using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Queries;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;

public class MeetingQueryService (IMeetingRepository meetingRepository) : IMeetingQueryService
{
    public async Task<IEnumerable<Meeting>> Handle(GetAllMeetingsQuery query)
    {
        return await meetingRepository.ListAsync();
    }

    public async Task<Meeting?> Handle(GetMeetingByIdQuery query)
    {
        return await meetingRepository.FindByIdAsync(query.MeetingId);
    }

    public Task<IEnumerable<Meeting>> Handle(GetAllMeetingByAdminIdQuery query)
    {
        return meetingRepository.FindAllByAdminIdAsync(query.AdminId);
    }
    
}