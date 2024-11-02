using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Application.Internal.QueryServices;

public class TeacherQueryService(ITeacherRepository teacherRepository) : ITeacherQueryService
{
    public async Task<Teacher?> GetByIdAsync(Guid id)
    {
        return await teacherRepository.FindByIdAsync(id);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await teacherRepository.ExistsByEmailAsync(email);
    }
}