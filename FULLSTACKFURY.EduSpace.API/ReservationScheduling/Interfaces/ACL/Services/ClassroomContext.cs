using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Services;
using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Domain.Repositories;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Interfaces.ACL.Services; 

public class ClassroomContext(IClassroomRepository classroomRepository) : IClassroomContext
{
    public bool ValidateClassroomNameExists(string name)
    {
        return classroomRepository.ExistsByClassroomName(name);
    }
}