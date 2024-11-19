using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.OutboundServices;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;


public class MeetingCommandService (
    IMeetingRepository meetingRepository,
    IUnitOfWork unitOfWork, 
    IRExternalProfileService profileService, 
    IExternalClassroomService classroomService) : IMeetingCommandService
{
    public async Task<Meeting?> Handle(CreateMeetingCommand command)
    {
        if(profileService.VerifyProfile(command.AdministratorId) == false) throw new Exception("Administrator not found");
        if (await meetingRepository.ExistsByTitleAsync(command.Title))
            throw new Exception("Title already exists");
        var meeting = new Meeting(command);
        await meetingRepository.AddAsync(meeting);
        await unitOfWork.CompleteAsync();
        return meeting;
    }

    public Task Handle(DeleteMeetingCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Meeting?> Handle(UpdateMeetingCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task Handle(AddTeacherToMeetingCommand command)
    {
        var meeting = await meetingRepository.FindByIdAsync(command.MeetingId);
        
        if (meeting == null)
            throw new ArgumentException("Meeting not found.");
        if (!externalProfileService.ValidateTeacherExistence(command.TeacherId))
            throw new ArgumentException("Teacher does not exist.");
        try
        {
            meeting.TeacherIdBuilder(command.TeacherId);
            meeting.AddTeacherToMeeting(command.MeetingId);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}