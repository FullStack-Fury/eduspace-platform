using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.ValueObjects;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;


public class MeetingCommandService (IMeetingRepository meetingRepository
    , IUnitOfWork unitOfWork, 
    IExternalProfileService externalProfileService, 
    IExternalClassroomService externalClassroomService) : IMeetingCommandService
{
    public async Task<Meeting?> Handle(CreateMeetingCommand command)
    {
        // var teacherIds = command.Teachers.Select(t => t.Id).ToList();
        // if (!externalProfileService.ValidateTeachersExistence(teacherIds))
        //     throw new ArgumentException("One or more teachers do not exist.");
        
        if (!externalProfileService.ValidateAdminIdExistence(command.AdministratorId))
            throw new ArgumentException("Admin ID does not exist.");
        
        if (!externalClassroomService.ValidateClassroomId(command.ClassroomId))
            throw new ArgumentException("Classroom does not exist.");
        
        // Create a new Meeting object
        var meeting = new Meeting(command);

        // Add the new meeting to the repository
        await meetingRepository.AddAsync(meeting);

        // Complete the transaction
        await unitOfWork.CompleteAsync();

        return meeting;
    }

    public async void Handle(DeleteMeetingCommand command)
    {
        var meeting = await meetingRepository.FindByIdAsync(command.MeetingId);
        if (meeting == null) throw new ArgumentException("Meeting not found.");

        meetingRepository.Remove(meeting);
    }
}