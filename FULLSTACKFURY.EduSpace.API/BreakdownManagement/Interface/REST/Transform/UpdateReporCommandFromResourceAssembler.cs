using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;

namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Transform
{
    public class UpdateReportCommandFromResourceAssembler
    {
        /// <summary>
        /// Converts an UpdateReportResource to an UpdateReportCommand.
        /// </summary>
        /// <param name="id">The ID of the report to be updated.</param>
        /// <param name="resource">The resource containing the report update details.</param>
        /// <returns>The UpdateReportCommand for updating the report.</returns>
        public static UpdateReportCommand ToCommand(int id, UpdateReportResource resource)
        {
            return new UpdateReportCommand(
                id,
                resource.Status
            );
        }
    }
}