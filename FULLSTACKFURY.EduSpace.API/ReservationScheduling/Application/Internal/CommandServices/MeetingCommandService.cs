using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Aggregates;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;


/// <summary>
/// Represents a command service for Meeting entities.
/// </summary>
/// <param name="meetingRepository">
/// The repository for meeting entities
/// </param>
/// <param name="administratorRepository">
/// The repository for administrator entities
/// </param>
/// <param name="unitOfWork">
/// The unit of work for the repository
/// </param>

/// <summary>
/// Represents a command service for Meeting entities.
/// </summary>
public class MeetingCommandService : IMeetingCommandService
{
    private readonly IMeetingRepository meetingRepository;
    private readonly IAdministratorRepository administratorRepository;
    private readonly IUnitOfWork unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="MeetingCommandService"/> class.
    /// </summary>
    /// <param name="meetingRepository">The repository for meeting entities.</param>
    /// <param name="administratorRepository">The repository for administrator entities.</param>
    /// <param name="unitOfWork">The unit of work for the repository.</param>
    public MeetingCommandService(IMeetingRepository meetingRepository,
        IAdministratorRepository administratorRepository,
        IUnitOfWork unitOfWork)
    {
        this.meetingRepository = meetingRepository;
        this.administratorRepository = administratorRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Meeting?> Handle(CreateMeetingCommand command)
    {
        var administrator = await administratorRepository.GetAdministratorByIdAsync(command.AdministratorId);
        if (administrator is null) throw new KeyNotFoundException("Administrator not found");

        if (await meetingRepository.ExistsByTitleAsync(command.Title))
            throw new InvalidOperationException("Meeting with the same title already exists");

        var meeting = await Meeting.CreateFromCommandAsync(command, 
            teacherRepository: null, // Reemplaza con el repositorio de profesores adecuado
            administratorRepository: administratorRepository);

        await meetingRepository.AddAsync(meeting);
        await unitOfWork.CompleteAsync();
        return meeting;
    }
}