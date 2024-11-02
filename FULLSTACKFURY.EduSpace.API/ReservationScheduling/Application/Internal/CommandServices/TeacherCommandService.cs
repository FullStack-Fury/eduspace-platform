using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Shared.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.CommandServices;

public class TeacherCommandService(
    ITeacherRepository teacherRepository,
    IUnitOfWork unitOfWork) : ITeacherCommandService
{
    public async Task<Teacher?> Handle(CreateTeacherCommand command)
    {
        if (await teacherRepository.ExistsByEmailAsync(command.Email))
            throw new Exception("Teacher with the same email already exists");

        var teacher = new Teacher(command);
        await teacherRepository.AddAsync(teacher);
        await unitOfWork.CompleteAsync();
        return teacher;
    }
}