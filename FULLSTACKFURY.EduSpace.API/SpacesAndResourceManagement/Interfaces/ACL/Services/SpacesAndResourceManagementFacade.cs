using FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Infrastructure.Persistence.EFC.Repositories;

namespace FULLSTACKFURY.EduSpace.API.SpacesAndResourceManagement.Interfaces.ACL.Services;

public class SpacesAndResourceManagementFacade(ClassroomRepository classroomRepository) : ISpacesAndResourceManagementFacade
{
    public bool ValidateClassroomIdExistence(int classroomId)
    {
        return classroomRepository.ExistsByClassroomId(classroomId);
    }
}