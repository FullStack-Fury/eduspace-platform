using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Transform
{
    public static class CreateReportCommandFromResourceAssembler
    {
        public static CreateReportCommand ToCommand(CreateReportResource resource)
        {
           
            return new CreateReportCommand(
                resource.TeacherId,
                resource.ResourceId,
                resource.KindOfReport,
                resource.Description,
                resource.Status,  // Ahora pasamos el string directamente
                resource.CreatedAt
            );
        }
    }
}